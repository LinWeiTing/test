using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2;
namespace WebApplication2.Service
{
    public class LineChatService
    {

        public Models.RestaurantDataBaseEntities restaurantDB;
        public provider provider { get; set; }

        public LineChatService()
        {

        }

        public List<RestaurantInformation> RestaurantInformationSearch(string Token)
        {
            restaurantDB = new Models.RestaurantDataBaseEntities();
          
                IQueryable<RestaurantInformation> restaurantCol = 
                           (from coty in restaurantDB.county
                           join cty in restaurantDB.city on coty.countyId equals cty.countyId
                           join rst in restaurantDB.restaurant on cty.cityId equals rst.cityId
                           join pro in restaurantDB.provider on rst.providerId equals pro.providerId
                           select new RestaurantInformation 
                           { 
                               restaurantName = rst.restaurantName,
                               restaurantNote = rst.restaurantNote,
                               countyName = coty.countyName,
                               cityName = cty.cityName,
                               restaurantAddress = rst.restaurantAddress,
                               restaurantPhone = rst.restaurantPhone,
                               providerLineId = pro.providerLineId,
                               providerName = pro.providerName,
                               restaurantPicture = rst.restaurantPicture,
                               restaurantURL = rst.restaurantURL
                           });

               return restaurantCol.Where(x => x.countyName == Token
                                    || x.cityName == Token
                                    || x.restaurantAddress.Contains(Token)
                                    || x.restaurantName.Contains(Token)
                                    || x.restaurantNote.Contains(Token)).ToList();
         
        }

        /// <summary>
        /// 檢核使用者
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="loginPwd"></param>
        /// <param name="isLogin"></param>
        /// <returns></returns>
        public bool CheckProvider(string loginID ,string loginPwd,bool isLogin)
        {
            restaurantDB = new Models.RestaurantDataBaseEntities();

            if(isLogin)
            {

                bool result = false;
               Models.provider entityObj = restaurantDB.provider.Where(x => x.providerPhone == loginID && x.providerLineId == loginPwd).FirstOrDefault();
                if(entityObj!= null)
                {
                    Utility.provider = new WebApplication2.provider();
                    Utility.provider.providerId = entityObj.providerId;
                    Utility.provider.providerLineId = entityObj.providerLineId;
                    Utility.provider.providerName = entityObj.providerName;
                    Utility.provider.providerPhone = entityObj.providerPhone;
                    result = true;
                }
                return result;
            }
            else
            {
                return restaurantDB.provider.Where(x => x.providerPhone == loginID).Any();
            }
            
        }

        
        public bool InsertProvder(provider provider)
        {
            try
            {
                restaurantDB = new Models.RestaurantDataBaseEntities();
                Models.provider insertObj = new Models.provider()
                {
                    providerLineId = provider.providerLineId,
                    providerName = provider.providerName,
                    providerPhone = provider.providerPhone
                };

                restaurantDB.provider.Add(insertObj);
                restaurantDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
        }

        public List<county> CountySearch()
        {
            restaurantDB = new Models.RestaurantDataBaseEntities();
            List<county> result = restaurantDB.county.Select(x => new county() 
            { 
                 countyId = x.countyId,
                 countyName = x.countyName
            }).ToList();
            return result;
        }


        public List<city> CitySearch(int countyId)
        {
            restaurantDB = new Models.RestaurantDataBaseEntities();

            List<city> result = (from c in restaurantDB.city
                                      where c.countyId == countyId
                                      select new city
                                      {
                                          cityId = c.cityId,
                                          cityName = c.cityName,
                                          countyId = c.countyId
                                      }).ToList();
            return result;
        }

        public bool InsertRestaurant(restaurant inObj)
        {
            try
            {
                restaurantDB = new Models.RestaurantDataBaseEntities();
                Models.restaurant result = new Models.restaurant()
                {
                    cityId = inObj.cityId,
                    providerId = inObj.providerId,
                    restaurantAddress = inObj.restaurantAddress,
                    restaurantName = inObj.restaurantName,
                    restaurantNote = inObj.restaurantNote,
                    restaurantPhone = inObj.restaurantPhone,
                    restaurantPicture = inObj.restaurantPicture,
                    restaurantURL = inObj.restaurantURL
                };

                restaurantDB.restaurant.Add(result);
                restaurantDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         
        }
    }
}