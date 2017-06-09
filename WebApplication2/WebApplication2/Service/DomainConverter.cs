using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2;
namespace WebApplication2.Service
{
    public static class DomainConverter
    {

        #region County
        /// <summary>
        /// 國家集合轉型
        /// </summary>
        /// <param name="entityCollecion"></param>
        /// <returns></returns>
        public static List<county> countyCollectionConvert(List<Models.county> entityCollecion)
        {
            List<county> result = new List<county>();

            foreach (Models.county entityObj in entityCollecion)
            {
                result.Add(countyConvert(entityObj));
            }

            return result;
        }

        /// <summary>
        /// 國家轉型
        /// </summary>
        /// <param name="entityObj"></param>
        /// <returns></returns>
        public static county countyConvert(Models.county entityObj)
        {
            county result = null;

            if (entityObj != null)
            {
                result = new county()
                {
                    countyId = entityObj.countyId,
                    countyName = entityObj.countyName,
                    cityCollection = cityCollectionConvert(entityObj.city.ToList())
                };
            }

            return result;
        }
        #endregion

        #region city
        /// <summary>
        /// 城市集合轉型
        /// </summary>
        /// <param name="entityCollecion"></param>
        /// <returns></returns>
        public static List<city> cityCollectionConvert(List<Models.city> entityCollecion)
        {
            List<city> result = new List<city>();

            foreach (Models.city entityObj in entityCollecion)
            {
                result.Add(cityConvert(entityObj));
            }

            return result;
        }

        /// <summary>
        /// 城市轉型
        /// </summary>
        /// <param name="entityObj"></param>
        /// <returns></returns>
        public static city cityConvert(Models.city entityObj)
        {
            city result = null;

            if (entityObj != null)
            {
                result = new city()
                {
                    cityId = entityObj.cityId,
                    cityName = entityObj.cityName,
                    countyId = entityObj.countyId,
                    county = countyConvert(entityObj.county),
                    restaurantCollection = restaurantCollectionConvert(entityObj.restaurant.ToList())
                };
            }

            return result;
        }
        #endregion

        #region restaurant
        /// <summary>
        /// 餐廳集合轉型
        /// </summary>
        /// <param name="entityCollecion"></param>
        /// <returns></returns>
        public static List<restaurant> restaurantCollectionConvert(List<Models.restaurant> entityCollecion)
        {
            List<restaurant> result = new List<restaurant>();

            foreach (Models.restaurant entityObj in entityCollecion)
            {
                result.Add(restaurantConvert(entityObj));
            }
            return result;
        }

        /// <summary>
        /// 餐廳轉型
        /// </summary>
        /// <param name="entityObj"></param>
        /// <returns></returns>
        public static restaurant restaurantConvert(Models.restaurant entityObj)
        {
            restaurant result = null;
            if (entityObj != null)
            {
                result = new restaurant()
                {
                    restaurantId = entityObj.restaurantId,
                    restaurantName = entityObj.restaurantName,
                    restaurantAddress = entityObj.restaurantAddress,
                    restaurantPhone = entityObj.restaurantPhone,
                    restaurantNote = entityObj.restaurantNote,
                    restaurantPicture = entityObj.restaurantPicture,
                    providerId = entityObj.providerId,
                    cityId = entityObj.cityId,
                    restaurantURL = entityObj.restaurantURL,
                    city = cityConvert(entityObj.city),
                    provider = providerConvert(entityObj.provider)
                };
            }

            return result;
        }
        #endregion

        #region provider
        /// <summary>
        /// 餐廳集合轉型
        /// </summary>
        /// <param name="entityCollecion"></param>
        /// <returns></returns>
        public static List<provider> providerCollectionConvert(List<Models.provider> entityCollecion)
        {
            List<provider> result = new List<provider>();

            foreach (Models.provider entityObj in entityCollecion)
            {
                result.Add(providerConvert(entityObj));
            }
            return result;
        }

        /// <summary>
        /// 餐廳轉型
        /// </summary>
        /// <param name="entityObj"></param>
        /// <returns></returns>
        public static provider providerConvert(Models.provider entityObj)
        {
            provider result = null;
            if (entityObj != null)
            {
                result = new provider()
                {
                    providerId = entityObj.providerId,
                    providerLineId = entityObj.providerLineId,
                    providerName = entityObj.providerName,
                    providerPhone = entityObj.providerPhone,
                    restaurant = restaurantCollectionConvert(entityObj.restaurant.ToList())
                };
            }

            return result;
        }
        #endregion
    }
}