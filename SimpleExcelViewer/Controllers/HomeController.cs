using Omu.AwesomeMvc;
using SimpleExcelViewer.Infrastructure.Services.Data;
using SimpleExcelViewer.Infrastructure.Services.Excel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimpleExcelViewer.Controllers
{
	public class HomeController : Controller
	{
		private readonly IExcelReaderService _excelService;
		private readonly IImportToDataStoreService _importService;

		public HomeController(IExcelReaderService excelService, IImportToDataStoreService importService)
		{
			_excelService = excelService;
			_importService = importService;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Index(HttpPostedFileBase file)
		{
			if (file.ContentLength > 0)
			{
				var fileName = Path.GetFileName(file.FileName);
				var extension = Path.GetExtension(file.FileName);
				if (extension == ".xls" || extension == ".xlsx")
				{
					var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
					file.SaveAs(path);

					var dataSet = await _excelService.GetDataSetFromFile(path);
					if (dataSet != null)
					{
						await _importService.ImportFromDataSet(dataSet);
					}
				}
			}

			return RedirectToAction("Index");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}