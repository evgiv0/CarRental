using Core.Common.Utils;
using CoreCommon.Annotations;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.OData.Query;


namespace CoreCommon.Core
{
    public class ObjectBase : INotifyPropertyChanged
    {
        public ObjectBase()
        {
            _validator = GetValidator();
            Validate();
        }

        private bool _isDirty;
        private IValidator _validator = null;

        protected IEnumerable<ValidationFailure> _validationErrors = null;

        private event PropertyChangedEventHandler _PropertyChanged;

        private List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_PropertyChangedSubscribers.Contains(value))
                {
                    _PropertyChanged += value;
                    _PropertyChangedSubscribers.Add(value);
                }
            }
            remove
            {
                _PropertyChanged -= value;
                _PropertyChangedSubscribers.Remove(value);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            _PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (makeDirty)
                _isDirty = true;
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }

        [NotNavigable]
        public bool IsDirty
        {
            get => _isDirty; set => _isDirty = value;
        }

        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject,
            Action<ObjectBase> snippetForList,
            params string[] exemptStrings)
        {
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool _exitWalk = snippetForObject.Invoke(o);

                    while (!_exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (var property in properties)
                        {
                            if (!exemptStrings.Contains(property.Name))
                            {

                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                                {
                                    ObjectBase obj = (ObjectBase)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForList.Invoke(o);

                                        foreach (var item in coll)
                                        {
                                            if (item is ObjectBase)
                                                walk((ObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

        }

        protected List<ObjectBase> GetDirtyObjects()
        {
            List<ObjectBase> dirtyObjects = new List<ObjectBase>();

            WalkObjectGraph(o =>
            {
                if (o.IsDirty)
                    dirtyObjects.Add(o);
                return false;
            }, coll => { });

            return dirtyObjects;
        }

        protected void CleanAll()
        {
            WalkObjectGraph(o =>
            {
                if (o.IsDirty)
                    o.IsDirty = false;
                return false;
            }, coll => { });
        }

        protected virtual bool IsAnythingDirty()
        {
            bool isDirty = false;

            WalkObjectGraph(o =>
            {
                if (o.IsDirty)
                {
                    isDirty = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }, coll => { });
            return isDirty;
        }

        private PropertyInfo[] GetBrowsableProperties()
        {
            throw new NotImplementedException();
        }

        #region Validation

        public virtual IValidator GetValidator()
        {
            return null;
        }

        [NotNavigable]
        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get { return _validationErrors; }
            set { }
        }


        public void Validate()
        {
            if (_validator != null)
            {
                ValidationResult result = _validator.Validate(this);
                _validationErrors = result.Errors;
            }
        }

        [NotNavigable]
        public bool IsValid
        {
            get
            {
                return (_validationErrors == null || !_validationErrors.Any());
            }
        }

        #endregion

    }
}
