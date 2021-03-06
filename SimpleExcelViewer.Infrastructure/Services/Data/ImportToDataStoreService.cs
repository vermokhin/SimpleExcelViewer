﻿using SimpleExcelViewer.Domain.Models;
using SimpleExcelViewer.Domain.Repositories;
using SimpleExcelViewer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Infrastructure.Services.Data
{
	public class ImportToDataStoreService : IImportToDataStoreService
	{
		private readonly IOfficeRepository _officeRepo;
		private readonly IManagerRepository _managerRepository;
		private readonly IEntityDataContext _context;

		public ImportToDataStoreService(IOfficeRepository officeRepo, IManagerRepository managerRepo, IEntityDataContext context)
		{
			_officeRepo = officeRepo;
			_managerRepository = managerRepo;
			_context = context;
		}

		private void ClearDataStore()
		{
			_context.Managers.Clear();
			_context.Offices.Clear();
		}

		public async Task ImportFromDataSet(DataSet dataSet)
		{
			try
			{
				ClearDataStore();
				foreach (var table in dataSet.Tables)
				{
					var dataTable = table as DataTable;
					if (dataTable != null)
					{
						await LoadOfficesToDataStore(dataTable);
						await LoadManagersToDataStore(dataTable);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private async Task LoadOfficesToDataStore(DataTable officesTable)
		{
			//try to create office
			if (officesTable.Columns.Count == 2)
			{
				var officeList = new List<Office>();
				foreach (var row in officesTable.Rows)
				{
					officeList.Add(new Office()
					{
						Id = Convert.ToInt32((row as DataRow)[0]),
						Name = (row as DataRow)[1].ToString()
					});
				}

				await _officeRepo.BulkAddAsync(officeList);
			}
		}

		private async Task LoadManagersToDataStore(DataTable managersTable)
		{
			//try to create managers
			if (managersTable.Columns.Count == 3)
			{
				var managersList = new List<Manager>();
				foreach (var row in managersTable.Rows)
				{
					managersList.Add(new Manager()
					{
						Id = Convert.ToInt32((row as DataRow)[0]),
						Name = (row as DataRow)[1].ToString(),
						Office_Id = Convert.ToInt32((row as DataRow)[2])
					});
				}
				await _managerRepository.BulkAddAsync(managersList);
			}
		}
	}
}