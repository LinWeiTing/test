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
            
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageActon() { label = "點選這邊等同用戶直接輸入某訊息", text = "/例如這樣" });
            actions.Add(new isRock.LineBot.UriActon() { label = "點這邊開啟網頁", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackActon() { label = "點這邊發生postack", data = "abc=aaa&def=111" });
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                altText = "替代文字(在無法顯示Button Template的時候顯示)",
                text = "123",
                title = "456",
            //設定圖片
                thumbnailImageUrl = new Uri("https://scontent-tpe1-1.xx.fbcdn.net/v/t31.0-8/15800635_1324407647598805_917901174271992826_o.jpg?oh=2fe14b080454b33be59cdfea8245406d&oe=591D5C94"),
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
                isRock.LineBot.Utility.PushTemplateMessage(ReceivedMessage.events[0].replyToken, ButtonTemplate, ChannelAccessToken);
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
