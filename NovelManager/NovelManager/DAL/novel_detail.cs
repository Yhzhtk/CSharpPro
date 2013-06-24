using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using DBUtility;//Please add references
namespace NovelManager.DAL
{
	/// <summary>
	/// 数据访问类:novel_detail
	/// </summary>
	public partial class novel_detail
	{
		public novel_detail()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(NovelManager.Model.novel_detail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            strSql1.Append("base_id,");
            strSql2.Append("" + model.base_id + ",");

            if (model.nid != null)
            {
                strSql1.Append("Nid,");
                strSql2.Append("'" + model.nid + "',");
            }
            if (model.url != null)
            {
                strSql1.Append("url,");
                strSql2.Append("'" + model.url + "',");
            }

            strSql1.Append("click,");
            strSql2.Append("" + model.click + ",");

            strSql1.Append("recommend,");
            strSql2.Append("" + model.recommend + ",");

            if (model.updatedate != null)
            {
                strSql1.Append("updatedate,");
                strSql2.Append("'" + model.updatedate + "',");
            }
            if (model.description != null)
            {
                strSql1.Append("description,");
                strSql2.Append("" + model.description + ",");
            }
            if (model.sourcesite != null)
            {
                strSql1.Append("sourcesite,");
                strSql2.Append("'" + model.sourcesite + "',");
            }
            if (model.chapter != null)
            {
                strSql1.Append("chapter,");
                strSql2.Append("" + model.chapter + ",");
            }
            if (model.blank_chapter != null)
            {
                strSql1.Append("blank_chapter,");
                strSql2.Append("'" + model.blank_chapter + "',");
            }
            if (model.cover_image != null)
            {
                strSql1.Append("cover_image,");
                strSql2.Append("'" + model.cover_image + "',");
            }
            strSql.Append("insert into novel_detail(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(NovelManager.Model.novel_detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update novel_detail set ");

            strSql.Append("base_id=" + model.base_id + ",");

            if (model.nid != null)
            {
                strSql.Append("Nid='" + model.nid + "',");
            }
            if (model.url != null)
            {
                strSql.Append("url='" + model.url + "',");
            }

            strSql.Append("click=" + model.click + ",");


            strSql.Append("recommend=" + model.recommend + ",");

            if (model.updatedate != null)
            {
                strSql.Append("updatedate='" + model.updatedate + "',");
            }
            if (model.description != null)
            {
                strSql.Append("description=" + model.description + ",");
            }
            else
            {
                strSql.Append("description= null ,");
            }
            if (model.sourcesite != null)
            {
                strSql.Append("sourcesite='" + model.sourcesite + "',");
            }
            if (model.chapter != null)
            {
                strSql.Append("chapter=" + model.chapter + ",");
            }
            else
            {
                strSql.Append("chapter= null ,");
            }
            if (model.blank_chapter != null)
            {
                strSql.Append("blank_chapter='" + model.blank_chapter + "',");
            }
            else
            {
                strSql.Append("blank_chapter= null ,");
            }
            if (model.cover_image != null)
            {
                strSql.Append("cover_image='" + model.cover_image + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where base_id="+model.base_id);
            int rowsAffected = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from novel_detail ");
			strSql.Append(" where " );
			int rowsAffected=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NovelManager.Model.novel_detail GetModel(string nid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" base_id,Nid,url,click,recommend,updatedate,description,sourcesite,chapter,blank_chapter,cover_image ");
			strSql.Append(" from novel_detail ");
			strSql.Append(" where Nid='"+nid+"'" );
			NovelManager.Model.novel_detail model=new NovelManager.Model.novel_detail();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["base_id"]!=null && ds.Tables[0].Rows[0]["base_id"].ToString()!="")
				{
					model.base_id=long.Parse(ds.Tables[0].Rows[0]["base_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Nid"]!=null && ds.Tables[0].Rows[0]["Nid"].ToString()!="")
				{
					model.nid=ds.Tables[0].Rows[0]["Nid"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url"]!=null && ds.Tables[0].Rows[0]["url"].ToString()!="")
				{
					model.url=ds.Tables[0].Rows[0]["url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["click"]!=null && ds.Tables[0].Rows[0]["click"].ToString()!="")
				{
					model.click=int.Parse(ds.Tables[0].Rows[0]["click"].ToString());
				}
				if(ds.Tables[0].Rows[0]["recommend"]!=null && ds.Tables[0].Rows[0]["recommend"].ToString()!="")
				{
					model.recommend=int.Parse(ds.Tables[0].Rows[0]["recommend"].ToString());
				}
				if(ds.Tables[0].Rows[0]["updatedate"]!=null && ds.Tables[0].Rows[0]["updatedate"].ToString()!="")
				{
					model.updatedate=ds.Tables[0].Rows[0]["updatedate"].ToString();
				}
				if(ds.Tables[0].Rows[0]["description"]!=null && ds.Tables[0].Rows[0]["description"].ToString()!="")
				{
					model.description=ds.Tables[0].Rows[0]["description"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sourcesite"]!=null && ds.Tables[0].Rows[0]["sourcesite"].ToString()!="")
				{
					model.sourcesite=ds.Tables[0].Rows[0]["sourcesite"].ToString();
				}
				if(ds.Tables[0].Rows[0]["chapter"]!=null && ds.Tables[0].Rows[0]["chapter"].ToString()!="")
				{
					model.chapter=ds.Tables[0].Rows[0]["chapter"].ToString();
				}
				if(ds.Tables[0].Rows[0]["blank_chapter"]!=null && ds.Tables[0].Rows[0]["blank_chapter"].ToString()!="")
				{
					model.blank_chapter=ds.Tables[0].Rows[0]["blank_chapter"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cover_image"]!=null && ds.Tables[0].Rows[0]["cover_image"].ToString()!="")
				{
					model.cover_image=ds.Tables[0].Rows[0]["cover_image"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select base_id,Nid,url,click,recommend,updatedate,description,sourcesite,chapter,blank_chapter,cover_image ");
			strSql.Append(" FROM novel_detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM novel_detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Cid desc");
			}
			strSql.Append(")AS Row, T.*  from novel_detail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPartList(string sql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sql);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSome(String sql)
        {
            int rowsAffected = DbHelperMySQL.ExecuteSql(sql);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}

