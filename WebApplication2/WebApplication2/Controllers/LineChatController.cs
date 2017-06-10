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

                string message = ReceivedMessage.events[0].message.text;

               List<isRock.LineBot.ButtonsTemplate> ButtonTemplateCol = RestaurantSearch(message);

               isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken,"您回傳的訊息："+ message, ChannelAccessToken);

                foreach(isRock.LineBot.ButtonsTemplate ButtonTemplate in  ButtonTemplateCol)
                {
                    isRock.LineBot.Utility.PushTemplateMessage(ReceivedMessage.events[0].source.userId, ButtonTemplate, ChannelAccessToken);

                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤：" + ex);
            }

            #region MyRegion
            /////建立actions，作為ButtonTemplate的用戶回覆行為
            //List<isRock.LineBot.TemplateActionBase> actions = new List<isRock.LineBot.TemplateActionBase>();
            ////actions.Add(new isRock.LineBot.MessageActon() { label = "標題-文字回覆", text = "回覆文字" });
            //actions.Add(new isRock.LineBot.UriActon() { label = "標題-開啟URL", uri = new Uri("http://140.124.72.4/professor.php") });
            ////actions.Add(new isRock.LineBot.PostbackActon() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            ////單一Button Template Message
            //isRock.LineBot.ButtonsTemplate ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            //{
            //    altText = "安安你好",
            //    text = "ButtonsTemplate文字訊息",
            //    title = "ButtonsTemplate標題",
            //    //設定圖片
            //    thumbnailImageUrl = new Uri("https://linechart-1.apphb.com/cctuan_photo.jpg"),
            //    actions = actions //設定回覆動作
            //};

            //try
            //{
            //    //取得 http Post RawData(should be JSON)
            //    string postData = Request.Content.ReadAsStringAsync().Result;
            //    //剖析JSON
            //    var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
            //    //回覆訊息
            //    string Message;
            //    Message = "你說了:" + ReceivedMessage.events[0].message.text;
            //    //回覆用戶
            //    isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
            //    isRock.LineBot.Utility.PushTemplateMessage(ReceivedMessage.events[0].source.userId, ButtonTemplate, ChannelAccessToken);


            //    //回覆API OK
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return Ok();
            //}
            #endregion
         
            return Ok();
        }

        
        private List<isRock.LineBot.ButtonsTemplate> RestaurantSearch(string Message)
        {

            List<isRock.LineBot.ButtonsTemplate> result = new List<isRock.LineBot.ButtonsTemplate>();
            try
            {

                List<RestaurantInformation> resaurantCol = _lineCatService.RestaurantInformationSearch(Message);

                foreach (RestaurantInformation obj in resaurantCol)
                {
                    List<isRock.LineBot.TemplateActionBase> actions = new List<isRock.LineBot.TemplateActionBase>();

                    actions.Add(new isRock.LineBot.UriActon() { label = "餐廳超連結：", uri = new Uri(obj.restaurantURL) });

                    isRock.LineBot.ButtonsTemplate resultObj = new isRock.LineBot.ButtonsTemplate()
                    {
                        altText = obj.restaurantName+"\r\n"+obj.restaurantNote+"\r\n"+obj.countyName+obj.cityName
                        +obj.restaurantAddress+"\r\n"+obj.restaurantPhone+"\r\n"+obj.providerLineId+" "+obj.providerName
                        +"\r\n"+obj.restaurantURL,
                        title=obj.restaurantName,
                        text = obj.restaurantNote + "\r\n" + obj.countyName + obj.cityName
                        + obj.restaurantAddress + "\r\n" + obj.restaurantPhone + "\r\n" + obj.providerLineId 
                        + " " + obj.providerName,
                        actions = actions
                    };
                    result.Add(resultObj);
                }
              

            }
            catch (Exception)
            {
              
              
            }


            return result;
        }
    }
}
