using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2;
namespace WebApplication2.Service
{
    public class LineChatService
    {

        public Models.RestaurantDataBaseEntities restaurantDB;

        public LineChatService()
        {

        }


        /// <summary>
        /// 取得該國家的資訊
        /// </summary>
        /// <param name="countyName"></param>
        /// <returns></returns>
        public county GetCounty(string countyName)
        {
            restaurantDB = new RestaurantDataBaseEntities();
            try
            {
                county result;

                Models.county entityObj = restaurantDB.county.Where(x => x.countyName == countyName).FirstOrDefault();

                if (entityObj != null)
                {
                    entityObj.city = restaurantDB.city.Where(x => x.countyId == entityObj.countyId).ToList();

                }
                    
               result = DomainConverter.countyConvert(entityObj);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢國家失敗：" + ex);
                return null;
            }
            
        }



        /// <summary>
        /// 取得城市資訊
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public city GetCity(string Message)
        {
            restaurantDB = new RestaurantDataBaseEntities();
            try
            {
                city result;

                Models.city entityObj = restaurantDB.city.Where(x => x.cityName == Message).FirstOrDefault();

                result = DomainConverter.cityConvert(entityObj);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢城市失敗：" + ex);
                return null;
            }
        }

        /// <summary>
        /// 取得餐廳資訊
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public restaurant GetResaurant(string Message)
        {
            restaurantDB = new RestaurantDataBaseEntities();
            try
            {
                restaurant result;

                Models.restaurant entityObj = restaurantDB.restaurant.Where(x => x.restaurantAddress == Message).FirstOrDefault();

                result = DomainConverter.restaurantConvert(entityObj);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢餐廳失敗：" + ex);
                return null;
            }
        }

        /// <summary>
        /// 取得餐廳集合
        /// </summary>
        /// <param name="cityIdCol"></param>
        /// <returns></returns>
        public List<restaurant> RestaurantSearch(List<int> cityIdCol)
        {
            restaurantDB = new RestaurantDataBaseEntities();
            try
            {
                List<restaurant> result;

                List<Models.restaurant> entityList = restaurantDB.restaurant.Where(x => cityIdCol.Contains((int)x.cityId)).ToList();

                result = DomainConverter.restaurantCollectionConvert(entityList);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢餐廳集合失敗：" + ex);
                return null;
            }
        }
    }
}