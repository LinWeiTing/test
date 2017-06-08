using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class LineChatController : ApiController
    {
        [HttpPost]
        public IHttpActionResult POST()
        {
            string ChannelAccessToken = "IltokqK2tMHOVqcWbuSU2FwuxFJpKednm3TNjcALhypZLJlegZzf9RFTWRSmsPnLfbcMHQBY32uarMSkWKY8AARV8N8+Bk77cbzyDhobwTg2H6J2BGVqZsjrxxbmjYLuIdnUab8CEE13qydXJlWcvQdB04t89/1O/w1cDnyilFU=";

            ///建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageActon() { label = "標題-文字回覆", text = "回覆文字" });
            actions.Add(new isRock.LineBot.UriActon() { label = "標題-開啟URL", uri = new Uri("http://140.124.72.4/professor.php") });
            actions.Add(new isRock.LineBot.PostbackActon() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                text = "ButtonsTemplate文字訊息",
                title = "ButtonsTemplate標題",
                //設定圖片
                thumbnailImageUrl = new Uri("http://140.124.72.4/img/lab/cctuan_photo.jpg"),
                actions = actions //設定回覆動作
            };

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = "你說了:" + ReceivedMessage.events[0].message.text;
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                isRock.LineBot.Utility.PushTemplateMessage(ReceivedMessage.events[0].source.userId, ButtonTemplate, ChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}
