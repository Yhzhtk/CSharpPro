using System;
using System.Data;
using System.Collections.Generic;
using NovelManager.Model;
namespace NovelManager.BLL
{
	/// <summary>
	/// novel_base
	/// </summary>
	public partial class novel_base
	{
		private readonly NovelManager.DAL.novel_base dal=new NovelManager.DAL.novel_base();
		public novel_base()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(NovelManager.Model.novel_base model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(NovelManager.Model.novel_base model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NovelManager.Model.novel_base GetModel(long id)
		{
			return dal.GetModel(id);
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
		public List<NovelManager.Model.novel_base> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NovelManager.Model.novel_base> DataTableToList(DataTable dt)
		{
			List<NovelManager.Model.novel_base> modelList = new List<NovelManager.Model.novel_base>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NovelManager.Model.novel_base model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NovelManager.Model.novel_base();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=long.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["Nid"]!=null && dt.Rows[n]["Nid"].ToString()!="")
					{
					model.nid=dt.Rows[n]["Nid"].ToString();
					}
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["author"]!=null && dt.Rows[n]["author"].ToString()!="")
					{
					model.author=dt.Rows[n]["author"].ToString();
					}
					if(dt.Rows[n]["chaptercount"]!=null && dt.Rows[n]["chaptercount"].ToString()!="")
					{
						model.chaptercount=int.Parse(dt.Rows[n]["chaptercount"].ToString());
					}
					if(dt.Rows[n]["blankchapter_type"]!=null && dt.Rows[n]["blankchapter_type"].ToString()!="")
					{
						model.blankchapter_type=int.Parse(dt.Rows[n]["blankchapter_type"].ToString());
					}
					if(dt.Rows[n]["blankchapter_count"]!=null && dt.Rows[n]["blankchapter_count"].ToString()!="")
					{
						model.blankchapter_count=int.Parse(dt.Rows[n]["blankchapter_count"].ToString());
					}
					if(dt.Rows[n]["novelstate"]!=null && dt.Rows[n]["novelstate"].ToString()!="")
					{
						model.novelstate=int.Parse(dt.Rows[n]["novelstate"].ToString());
					}
					if(dt.Rows[n]["type"]!=null && dt.Rows[n]["type"].ToString()!="")
					{
					model.type=dt.Rows[n]["type"].ToString();
					}
					if(dt.Rows[n]["no_desc"]!=null && dt.Rows[n]["no_desc"].ToString()!="")
					{
						model.no_desc=int.Parse(dt.Rows[n]["no_desc"].ToString());
					}
					if(dt.Rows[n]["state"]!=null && dt.Rows[n]["state"].ToString()!="")
					{
						model.state=int.Parse(dt.Rows[n]["state"].ToString());
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


        #region 自写方法
        /// <summary>
        /// 获得指定字段数据列表
        /// </summary>
        public DataSet GetPartList(string sql)
        {
            return dal.GetPartList(sql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NovelManager.Model.novel_base GetModelFromNid(string nid)
        {
            return dal.GetModelFromNid(nid);
        }

        #endregion

        internal bool UpdateSome(string sql)
        {
            return dal.UpdateSome(sql);
        }
    }
}

