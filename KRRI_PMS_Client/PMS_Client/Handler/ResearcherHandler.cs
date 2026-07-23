using PMS_Common.Packets;

namespace PMS_Client.Handler
{
    /// <summary>
    /// 연구원 조회 결과를 처리합니다.
    /// </summary>
    public class ResearcherResponseHandler
    {
        //public async Task ProcessAsync(ResearcherSearchResponse response)
        //{
        //    if (response.Success)
        //    {
        //        Console.WriteLine($"조회 결과 : {response.Researchers.Count}명");

        //        foreach (var researcher in response.Researchers)
        //        {
        //            Console.WriteLine(
        //                $"{researcher.ResearcherID} | " +
        //                $"{researcher.Name} | " +
        //                $"{researcher.Department}");
        //        }

        //        // TODO :
        //        // ObservableCollection에 추가
        //        // DataGrid 갱신
        //    }
        //    else
        //    {
        //        Console.WriteLine(response.Message);

        //        // TODO :
        //        // MessageBox.Show(response.Message);
        //    }

        //    await Task.CompletedTask;
        //}
    }
}