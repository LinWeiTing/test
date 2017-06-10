using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class RestaurantInformation
    {
        /// <summary>
        /// 餐廳名稱
        /// </summary>
        public string restaurantName { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        public string restaurantNote { get; set; }

        /// <summary>
        /// 國家名稱
        /// </summary>
        public string countyName { get; set; }

        /// <summary>
        /// 城市名稱
        /// </summary>
        public string cityName { get; set; }

        /// <summary>
        /// 餐廳地址
        /// </summary>
        public string restaurantAddress { get; set; }

        /// <summary>
        /// 餐廳電話
        /// </summary>
        public string restaurantPhone { get; set; }

        /// <summary>
        /// 業務LineID
        /// </summary>
        public string providerLineId { get; set; }

        /// <summary>
        /// 業務姓名
        /// </summary>
        public string providerName { get; set; }

        /// <summary>
        /// 餐廳照片
        /// </summary>
        public string restaurantPicture { get; set; }

        /// <summary>
        /// 餐廳超連結
        /// </summary>
        public string restaurantURL { get; set; }
    }
}