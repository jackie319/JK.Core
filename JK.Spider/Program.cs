using DotnetSpider.Core;
using DotnetSpider.Core.Scheduler;
using System;
using System.Collections.Generic;

namespace JK.Spider
{
    class Program
    {
        static void Main(string[] args)
        {
            var site = new Site
            {
                CycleRetryTimes = 1,
                SleepTime = 200,
                DownloadFiles = true,     //DotNetSpider中设置是否下载文件
                //Headers = new Dictionary<string, string>()
                //{
                //    { "Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8" },
                //    { "Cache-Control","no-cache" },
                //    { "Connection","keep-alive" },
                //    { "Content-Type","application/x-www-form-urlencoded; charset=UTF-8" },
                //    {"token","01j32ksie3j9jd893d"},
                //    { "User-Agent","Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36"}
                //}

            };
            List<Request> resList = new List<Request>();
            Request res = new Request();
            res.Url = "http://maimaiyin.cn/home/More?catcage=catcage";
            res.Method = System.Net.Http.HttpMethod.Get;
            resList.Add(res);
            var spider = Spider.Create(site, new QueueDuplicateRemovedScheduler(), new GetMMYProcessor())
                .AddStartRequests(resList.ToArray())
                .AddPipeline(new PrintImgInfoPipe());
            spider.ThreadNum = 1;
            spider.Run();
            Console.Read();
        }


        private class GetMMYProcessor : BasePageProcessor
        {
            public GetMMYProcessor()
            {
            }
            protected override void Handle(Page page)
            {
                List<ImgInfoModel> logoInfoList = new List<ImgInfoModel>();
                var logoInfoNodes = page.Selectable.XPath(".//div[@class='suwis-special-bottom-list clear']//li").Nodes();
                foreach (var logoInfo in logoInfoNodes)
                {
                    ImgInfoModel model = new ImgInfoModel();
                    model.Name = logoInfo.XPath(".//div[@class='suwis-special-b-l-text']").GetValue();
                    model.ImgPath = logoInfo.XPath(".//div[@class='suwis-special-b-l-img']//img/@src").GetValue();
                    if (model.ImgPath.IndexOf("http") == -1)
                    {
                        model.ImgPath = "http:" + model.ImgPath;
                    }
                    logoInfoList.Add(model);
                    page.AddTargetRequest(model.ImgPath); //Site设置DownloadFiles为TRUE就可以自动下载文件
                }
                page.AddResultItem("ImgInfoList", logoInfoList);

            }

        }


        private class PrintImgInfoPipe : BasePipeline
        {

            public override void Process(IEnumerable<ResultItems> resultItems, ISpider spider)
            {

                foreach (var resultItem in resultItems)
                {
                    var logoInfoList = resultItem.GetResultItem("ImgInfoList") as List<ImgInfoModel>;
                    foreach (var logoInfo in logoInfoList)
                    {
                        Console.WriteLine($"Name:{logoInfo.Name} path:{logoInfo.ImgPath}");
                        SaveFile(logoInfo.ImgPath, Guid.NewGuid().ToString());//自己写的下载类
                    }
                }
            }
            private void SaveFile(string url, string filename)
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.RequestUri = new Uri(url);
                httpRequestMessage.Method = HttpMethod.Get;
                HttpClient httpClient = new HttpClient();
                var httpResponse = httpClient.SendAsync(httpRequestMessage);
                var intervalPath = new Uri(url);
                string filePath = Environment.CurrentDirectory + "/img/";
                if (!File.Exists(filePath))
                {
                    try
                    {
                        string folder = Path.GetDirectoryName(filePath);
                        if (!string.IsNullOrWhiteSpace(folder))
                        {
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }
                        }

                        File.WriteAllBytes(filePath + filename + ".jpg", httpResponse.Result.Content.ReadAsByteArrayAsync().Result);
                    }
                    catch
                    {
                    }
                }
                httpClient.Dispose();
            }
        }

        private class ImgInfoModel
        {
            public string Name { get; set; }
            public string ImgPath { get; set; }
        }
    }
}
