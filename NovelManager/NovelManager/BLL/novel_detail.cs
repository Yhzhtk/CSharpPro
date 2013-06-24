using System;
using System.Data;
using System.Collections.Generic;
using NovelManager.Model;
namespace NovelManager.BLL
{
	/// <summary>
	/// novel_detail
	/// </summary>
	public partial class novel_detail
	{
		private readonly NovelManager.DAL.novel_detail dal=new NovelManager.DAL.novel_detail();
		public novel_detail()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(NovelManager.Model.novel_detail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(NovelManager.Model.novel_detail model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NovelManager.Model.novel_detail GetModel(string nid)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(nid);
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
		public List<NovelManager.Model.novel_detail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NovelManager.Model.novel_detail> DataTableToList(DataTable dt)
		{
			List<NovelManager.Model.novel_detail> modelList = new List<NovelManager.Model.novel_detail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NovelManager.Model.novel_detail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NovelManager.Model.novel_detail();
					if(dt.Rows[n]["base_id"]!=null && dt.Rows[n]["base_id"].ToString()!="")
					{
						model.base_id=long.Parse(dt.Rows[n]["base_id"].ToString());
					}
					if(dt.Rows[n]["Nid"]!=null && dt.Rows[n]["Nid"].ToString()!="")
					{
					model.nid=dt.Rows[n]["Nid"].ToString();
					}
					if(dt.Rows[n]["url"]!=null && dt.Rows[n]["url"].ToString()!="")
					{
					model.url=dt.Rows[n]["url"].ToString();
					}
					if(dt.Rows[n]["click"]!=null && dt.Rows[n]["click"].ToString()!="")
					{
						model.click=int.Parse(dt.Rows[n]["click"].ToString());
					}
					if(dt.Rows[n]["recommend"]!=null && dt.Rows[n]["recommend"].ToString()!="")
					{
						model.recommend=int.Parse(dt.Rows[n]["recommend"].ToString());
					}
					if(dt.Rows[n]["updatedate"]!=null && dt.Rows[n]["updatedate"].ToString()!="")
					{
					model.updatedate=dt.Rows[n]["updatedate"].ToString();
					}
					if(dt.Rows[n]["description"]!=null && dt.Rows[n]["description"].ToString()!="")
					{
					model.description=dt.Rows[n]["description"].ToString();
					}
					if(dt.Rows[n]["sourcesite"]!=null && dt.Rows[n]["sourcesite"].ToString()!="")
					{
					model.sourcesite=dt.Rows[n]["sourcesite"].ToString();
					}
					if(dt.Rows[n]["chapter"]!=null && dt.Rows[n]["chapter"].ToString()!="")
					{
					model.chapter=dt.Rows[n]["chapter"].ToString();
					}
					if(dt.Rows[n]["blank_chapter"]!=null && dt.Rows[n]["blank_chapter"].ToString()!="")
					{
					model.blank_chapter=dt.Rows[n]["blank_chapter"].ToString();
					}
					if(dt.Rows[n]["cover_image"]!=null && dt.Rows[n]["cover_image"].ToString()!="")
					{
					model.cover_image=dt.Rows[n]["cover_image"].ToString();
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


        /// <summary>
        /// 获得指定字段数据列表
        /// </summary>
        public DataSet GetPartList(string sql)
        {
            return dal.GetPartList(sql);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSome(String sql)
        {
            return dal.UpdateSome(sql);
        }
	}
}

