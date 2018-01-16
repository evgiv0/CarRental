using System.Runtime.Serialization;

namespace CoreCommon.Core
{
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
