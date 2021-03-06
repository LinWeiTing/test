USE [dbc77f7eb3a51848168c8ca78d00e74488]
GO
/****** Object:  Table [dbo].[city]    Script Date: 2017/6/10 上午 03:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[cityId] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [nvarchar](20) NULL,
	[countyId] [int] NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[cityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[county]    Script Date: 2017/6/10 上午 03:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[county](
	[countyId] [int] IDENTITY(1,1) NOT NULL,
	[countyName] [nchar](3) NULL,
 CONSTRAINT [PK_county] PRIMARY KEY CLUSTERED 
(
	[countyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[provider]    Script Date: 2017/6/10 上午 03:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provider](
	[providerId] [int] IDENTITY(1,1) NOT NULL,
	[providerName] [nvarchar](50) NULL,
	[providerPhone] [nchar](12) NULL,
	[providerLineId] [nvarchar](50) NULL,
 CONSTRAINT [PK_provider] PRIMARY KEY CLUSTERED 
(
	[providerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[restaurant]    Script Date: 2017/6/10 上午 03:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restaurant](
	[restaurantId] [int] IDENTITY(1,1) NOT NULL,
	[restaurantName] [nvarchar](50) NULL,
	[restaurantAddress] [nvarchar](max) NOT NULL,
	[restaurantPhone] [nvarchar](12) NULL,
	[restaurantNote] [nvarchar](max) NULL,
	[restaurantPicture] [nvarchar](max) NULL,
	[restaurantURL] [nvarchar](max) NULL,
	[cityId] [int] NULL,
	[providerId] [int] NOT NULL,
 CONSTRAINT [PK_restaurant] PRIMARY KEY CLUSTERED 
(
	[restaurantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[city] ON 

INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (1, N'松山區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (2, N'信義區 ', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (3, N'大安區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (4, N'中山區 ', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (5, N'中正區 ', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (6, N'大同區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (7, N'萬華區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (8, N'文山區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (9, N'南港區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (10, N'內湖區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (11, N'士林區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (12, N'北投區', 1)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (13, N'板橋區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (14, N'三重區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (15, N'中和區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (16, N'永和區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (17, N'新莊區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (18, N'新店區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (19, N'土城區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (20, N'蘆洲區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (21, N'汐止區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (22, N'樹林區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (23, N'淡水區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (24, N'鶯歌區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (25, N'三峽區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (26, N'瑞芳區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (27, N'五股區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (28, N'泰山區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (29, N'林口區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (30, N'深坑區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (31, N'石碇區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (32, N'坪林區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (33, N'三芝區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (34, N'石門區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (35, N'八里區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (36, N'平溪區 ', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (37, N'雙溪區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (38, N'貢寮區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (39, N'金山區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (40, N'萬里區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (41, N'烏來區', 2)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (42, N'宜蘭市', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (43, N'羅東鎮 ', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (44, N'蘇澳鎮', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (45, N'頭城鎮', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (46, N'礁溪鄉 ', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (47, N'壯圍鄉', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (48, N'員山鄉 ', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (49, N'冬山鄉 ', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (50, N'五結鄉 ', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (51, N'三星鄉 ', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (52, N'大同鄉', 17)
INSERT [dbo].[city] ([cityId], [cityName], [countyId]) VALUES (53, N'南澳鄉 ', 17)
SET IDENTITY_INSERT [dbo].[city] OFF
SET IDENTITY_INSERT [dbo].[county] ON 

INSERT [dbo].[county] ([countyId], [countyName]) VALUES (1, N'臺北市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (2, N'新北市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (3, N'桃園市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (4, N'臺中市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (5, N'臺南市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (6, N'高雄市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (7, N'基隆市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (8, N'新竹市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (9, N'嘉義市')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (10, N'新竹縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (11, N'苗栗縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (12, N'彰化縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (13, N'南投縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (14, N'雲林縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (15, N'嘉義縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (16, N'屏東縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (17, N'宜蘭縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (18, N'花蓮縣')
INSERT [dbo].[county] ([countyId], [countyName]) VALUES (19, N'臺東縣')
SET IDENTITY_INSERT [dbo].[county] OFF
SET IDENTITY_INSERT [dbo].[provider] ON 

INSERT [dbo].[provider] ([providerId], [providerName], [providerPhone], [providerLineId]) VALUES (1, N'林韋廷', N'0952259389  ', N'sp036239')
INSERT [dbo].[provider] ([providerId], [providerName], [providerPhone], [providerLineId]) VALUES (2, N'張庭榮', N'0927706885  ', N'qq40890123')
SET IDENTITY_INSERT [dbo].[provider] OFF
SET IDENTITY_INSERT [dbo].[restaurant] ON 

INSERT [dbo].[restaurant] ([restaurantId], [restaurantName], [restaurantAddress], [restaurantPhone], [restaurantNote], [restaurantPicture], [restaurantURL], [cityId], [providerId]) VALUES (1, N'海世界複合式碳烤店', N'古結村古結路49號', N'039373885', N'史上最划算 500元海鮮炭烤吃到飽', N'1.jpg', N'https://g.co/kgs/mL6mMw', 47, 1)
INSERT [dbo].[restaurant] ([restaurantId], [restaurantName], [restaurantAddress], [restaurantPhone], [restaurantNote], [restaurantPicture], [restaurantURL], [cityId], [providerId]) VALUES (3, N'誠屋拉麵', N'中山北路二段78號之3', N'0225218159', N'只要399元(雙人價)即可享用【誠屋拉麵《寶慶店》】原價670元絕對美味雙人拉麵套餐', N'3.jpg', N'http://www.makotoya.com.tw/', 4, 2)
INSERT [dbo].[restaurant] ([restaurantId], [restaurantName], [restaurantAddress], [restaurantPhone], [restaurantNote], [restaurantPicture], [restaurantURL], [cityId], [providerId]) VALUES (5, N'海霸王', N'長安西路287號', N'0225522205', N'長安店涵蓋三個樓層，單層最多可容納55桌', N'5.jpg', N'https://goo.gl/ptl48v', 6, 1)
INSERT [dbo].[restaurant] ([restaurantId], [restaurantName], [restaurantAddress], [restaurantPhone], [restaurantNote], [restaurantPicture], [restaurantURL], [cityId], [providerId]) VALUES (7, N'甕窯雞', N'礁溪路七段23號', N'0918717288', N'聯合報專題報導-阿媽的老祕方', N'7.jpg', N'http://www.0918717288.com/', 46, 2)
INSERT [dbo].[restaurant] ([restaurantId], [restaurantName], [restaurantAddress], [restaurantPhone], [restaurantNote], [restaurantPicture], [restaurantURL], [cityId], [providerId]) VALUES (8, N'李師傅的店', N'國光路61號', N'0989778882', N'道地港式點心~永和銅板美食，不用到大飯店也可以吃CP值高港式茶點!', N'8.jpg', N'https://goo.gl/kMu8Kh', 16, 1)
SET IDENTITY_INSERT [dbo].[restaurant] OFF
ALTER TABLE [dbo].[city]  WITH CHECK ADD  CONSTRAINT [FK_city_county] FOREIGN KEY([countyId])
REFERENCES [dbo].[county] ([countyId])
GO
ALTER TABLE [dbo].[city] CHECK CONSTRAINT [FK_city_county]
GO
ALTER TABLE [dbo].[restaurant]  WITH CHECK ADD  CONSTRAINT [FK_restaurant_city] FOREIGN KEY([cityId])
REFERENCES [dbo].[city] ([cityId])
GO
ALTER TABLE [dbo].[restaurant] CHECK CONSTRAINT [FK_restaurant_city]
GO
ALTER TABLE [dbo].[restaurant]  WITH CHECK ADD  CONSTRAINT [FK_restaurant_provider] FOREIGN KEY([providerId])
REFERENCES [dbo].[provider] ([providerId])
GO
ALTER TABLE [dbo].[restaurant] CHECK CONSTRAINT [FK_restaurant_provider]
GO
