//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class restaurant
    {
        public int restaurantId { get; set; }
        public string restaurantName { get; set; }
        public string restaurantAddress { get; set; }
        public string restaurantPhone { get; set; }
        public string restaurantNote { get; set; }
        public string restaurantPicture { get; set; }
        public string restaurantURL { get; set; }
        public Nullable<int> cityId { get; set; }
        public int providerId { get; set; }
    
        public virtual city city { get; set; }
        public virtual provider provider { get; set; }
    }
}
