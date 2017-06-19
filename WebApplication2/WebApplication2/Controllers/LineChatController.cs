using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2;
using WebApplication2.Service;
using System.Web;
//using System.Web.Mvc;
namespace WebApplication2.Controllers
{
    public class LineChatController : ApiController
    {
        public Service.LineChatService _lineCatService;

        [HttpPost]
        public IHttpActionResult POST()
        {
            _lineCatService = new LineChatService();
            string ChannelAccessToken = "IltokqK2tMHOVqcWbuSU2FwuxFJpKednm3TNjcALhypZLJlegZzf9RFTWRSmsPnLfbcMHQBY32uarMSkWKY8AARV8N8+Bk77cbzyDhobwTg2H6J2BGVqZsjrxxbmjYLuIdnUab8CEE13qydXJlWcvQdB04t89/1O/w1cDnyilFU=";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);

                #region 圖片取得
                if (ReceivedMessage.events.FirstOrDefault().type == "message" &&
                   ReceivedMessage.events.FirstOrDefault().message.type.Trim().ToLower() == "image")
                {
                    //取得contentid
                    var LineContentID = ReceivedMessage.events.FirstOrDefault().message.id.ToString();
                    var filebody = isRock.LineBot.Utility.GetUserUploadedContent(LineContentID, ChannelAccessToken);
                    //建立唯一名稱
                    var filename = "https://linechart-1.apphb.com/Image/" + "MyImage.png";
                    var path = System.Web.HttpContext.Current.Request.MapPath(filename);
                    //save
                    System.IO.File.WriteAllBytes(path, filebody);
                }
                #endregion

                string message = ReceivedMessage.events[0].message.text;

                isRock.LineBot.CarouselTemplate carouselTemplate = RestaurantSearch(ReceivedMessage.events[0].source.userId, message, ChannelAccessToken);

                isRock.LineBot.Utility.PushTemplateMessage(ReceivedMessage.events[0].source.userId, carouselTemplate, ChannelAccessToken);
           
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤：" + ex);
            }

            return Ok();
        }

        /// <summary>
        /// 查詢餐廳資訊
        /// </summary>
        /// <param name="replyToken"></param>
        /// <param name="Message"></param>
        /// <param name="ChannelAccessToken"></param>
        /// <returns></returns>
        private isRock.LineBot.CarouselTemplate RestaurantSearch(string replyToken, string Message, string ChannelAccessToken)
        {

            isRock.LineBot.CarouselTemplate result = new isRock.LineBot.CarouselTemplate();
            try
            {

                List<RestaurantInformation> resaurantCol = _lineCatService.RestaurantInformationSearch(Message.Trim());

                result.altText = Message + "，查詢到的資料筆數：" + resaurantCol.Count.ToString();

                if(!resaurantCol.Any())
                {
                    isRock.LineBot.Utility.PushMessage(replyToken, Message + "，查無資料", ChannelAccessToken);
                }

                foreach (RestaurantInformation obj in resaurantCol)
                {

                    isRock.LineBot.Utility.PushMessage(replyToken, 
                        obj.restaurantName+"\r\n"
                        +obj.restaurantNote+"\r\n"
                        +"======================="
                        + "地址：" + obj.countyName + obj.cityName + obj.restaurantAddress + "\r\n"
                        + "電話：" + obj.restaurantPhone + "\r\n"
                        +"分享者ID："+ obj.providerLineId + "\r\n"
                        + "分享者：" + obj.providerName + "\r\n"
                        + "傳送門：" + obj.restaurantURL,
                        ChannelAccessToken);


                    List<isRock.LineBot.TemplateActionBase> actions = new List<isRock.LineBot.TemplateActionBase>();

                    actions.Add(new isRock.LineBot.UriActon() { label = "餐廳傳送門 <3", uri = new Uri(obj.restaurantURL) });


                    isRock.LineBot.Column resultObj = new isRock.LineBot.Column()
                    {
                        
                        //標題
                        title = obj.restaurantName,

                        //文字
                        text = "地址：" + obj.countyName + obj.cityName+  obj.restaurantAddress + "\r\n"
                        + "電話：" + obj.restaurantPhone,
                        
                        //URL
                        actions = actions,

                        //圖片
                        thumbnailImageUrl = new Uri("https://linechart-1.apphb.com/Image/" + obj.restaurantPicture)
                    };

                    result.columns.Add(resultObj);
                }

            }
            catch (Exception ex)
            {

                isRock.LineBot.Utility.PushMessage(replyToken, "餐廳查詢失敗：" + ex, ChannelAccessToken);
            }


            return result;
        }
    }
}
