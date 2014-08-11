using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Enums;

namespace Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MetadataAttribute : Attribute
    {
        public string Title { get; set; }
        public State State { get; set; }
        public ControlType ControlType { get; set; }
    }
}