//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntTVapi.EntityDataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class NEWS
    {
        public int newsID { get; set; }
        public string newsCategory { get; set; }
        public string newsGenre { get; set; }
        public string newsName { get; set; }
        public string newsDescription { get; set; }
        public System.DateTime newsDateTime { get; set; }
        public string newsMainPictureLink { get; set; }
        public string newsVideoLink { get; set; }
        public bool newsPrefered { get; set; }
    }
}
