using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Attributes;
using Entity.Enums;

namespace Entity
{
    public class Foo
    {
        public int Id { get; set; }

        [Metadata(Title = "Başlık", State = State.Online, ControlType = ControlType.TextBox)]
        public string Title { get; set; }

        [Metadata(Title = "Ad", State = State.Offline, ControlType = ControlType.CheckBox)]
        public string FirstName { get; set; }
    }
}