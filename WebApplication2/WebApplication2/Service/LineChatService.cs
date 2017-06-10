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

        public List<RestaurantInformation> RestaurantInformationSearch(string Token)
        {
            restaurantDB = new RestaurantDataBaseEntities();
          
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
                                    || x.restaurantName == Token
                                    || x.restaurantAddress == Token).ToList();
         
        }
    }
}