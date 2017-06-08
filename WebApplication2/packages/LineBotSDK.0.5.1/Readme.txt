================================================
LineBot SDK for .NET (Line@ Messaging API supported)
這是用來開發LineBot的C# SDK
================================================

支援Line@ Messanging API(V2), LineNotify
(目前已支援text, image, sticker, template message傳送)

簡易使用說明:
Push Message(主動發訊息給用戶):
isRock.LineBot.Utility.PushMessage(用戶id, 文字訊息, AccessToken);

Parsing Receieved Message(Parsing 收到的JSON): 
var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);

Reply Message(回覆用戶的訊息):
isRock.LineBot.Utility.ReplyMessage(ReplyToken, 文字訊息, AccessToken);

================================================
使用套件有得有失，使用前請詳閱套件公開說明書，
套件發行單位過去之績效並不表示您使用此套件將會凡事順利。
================================================

如何使用請參考套件公開說明書:
http://studyhost.blogspot.tw/search/label/LineBot
