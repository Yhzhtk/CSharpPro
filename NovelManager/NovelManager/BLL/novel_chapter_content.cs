using System;
using System.Data;
using System.Collections.Generic;
using NovelManager.Model;
namespace NovelManager.BLL
{
	/// <summary>
	/// novel_chapter_content
	/// </summary>
	public partial class novel_chapter_content
	{
		private readonly NovelManager.DAL.novel_chapter_content dal=new NovelManager.DAL.novel_chapter_content();
		public novel_chapter_content()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string nid,int cid)
		{
			return dal.Exists(nid,cid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(NovelManager.Model.novel_chapter_content model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(NovelManager.Model.novel_chapter_content model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string nid,int cid)
		{
			
			return dal.Delete(nid,cid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NovelManager.Model.novel_chapter_content GetModel(string nid,int cid)
		{
			
			return dal.GetModel(nid,cid);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NovelManager.Model.novel_chapter_content> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NovelManager.Model.novel_chapter_content> DataTableToList(DataTable dt)
		{
			List<NovelManager.Model.novel_chapter_content> modelList = new List<NovelManager.Model.novel_chapter_content>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NovelManager.Model.novel_chapter_content model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NovelManager.Model.novel_chapter_content();
					if(dt.Rows[n]["base_id"]!=null && dt.Rows[n]["base_id"].ToString()!="")
					{
						model.base_id=long.Parse(dt.Rows[n]["base_id"].ToString());
					}
					if(dt.Rows[n]["Nid"]!=null && dt.Rows[n]["Nid"].ToString()!="")
					{
					model.nid=dt.Rows[n]["Nid"].ToString();
					}
					if(dt.Rows[n]["Cid"]!=null && dt.Rows[n]["Cid"].ToString()!="")
					{
						model.cid=int.Parse(dt.Rows[n]["Cid"].ToString());
					}
					if(dt.Rows[n]["Content"]!=null && dt.Rows[n]["Content"].ToString()!="")
					{
					model.content=dt.Rows[n]["Content"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

