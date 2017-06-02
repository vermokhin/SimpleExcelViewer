using Omu.AwesomeMvc;
using SimpleExcelViewer.Domain.Models;
using SimpleExcelViewer.Domain.Repositories;
using SimpleExcelViewer.Infrastructure.Services.Data;
using SimpleExcelViewer.Infrastructure.Services.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimpleExcelViewer.Controllers
{
	public class HomeController : Controller
	{
		private readonly IExcelReaderService _excelService;
		private readonly IImportToDataStoreService _importService;
		private readonly IOfficeRepository _officeReposotory;
		private readonly IManagerRepository _managerRepository;

		public HomeController(IExcelReaderService excelService, IImportToDataStoreService importService, IOfficeRepository officeRepository, IManagerRepository managerRepository)
		{
			_excelService = excelService;
			_importService = importService;
			_officeReposotory = officeRepository;
			_managerRepository = managerRepository;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult ManagerGrid(int key)
		{
			ViewData["Id"] = key;
			return PartialView("~/Views/Home/Managers.cshtml");
		}


		public ActionResult GetOfficesForGrid(GridParams g)
		{
			return Json(new GridModelBuilder<Office>(_officeReposotory.GetAll(), g)
			{
				Key = "Id"
			}.Build());
		}

		public ActionResult GetManagersForOffice(GridParams g, int officeId)
		{
			return Json(new GridModelBuilder<Manager>(_managerRepository.GetManagersFromOffice(officeId).OrderBy(s=>s.Id), g).Build());
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