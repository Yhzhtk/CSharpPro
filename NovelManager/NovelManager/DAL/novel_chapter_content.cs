using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using DBUtility;//Please add references
namespace NovelManager.DAL
{
	/// <summary>
	/// 数据访问类:novel_chapter_content
	/// </summary>
	public partial class novel_chapter_content
	{
		public novel_chapter_content()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("Cid", "novel_chapter_content"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string nid,int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from novel_chapter_content");
			strSql.Append(" where Nid='"+nid+"' and Cid="+cid+" ");
			return DbHelperMySQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(NovelManager.Model.novel_chapter_content model)
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

            strSql1.Append("Cid,");
            strSql2.Append("" + model.cid + ",");

            if (model.content != null)
            {
                strSql1.Append("Content,");
                strSql2.Append("'" + model.content + "',");
            }
            strSql.Append("insert into novel_chapter_content(");
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
        public bool Update(NovelManager.Model.novel_chapter_content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update novel_chapter_content set ");

            strSql.Append("base_id=" + model.base_id + ",");

            if (model.content != null)
            {
                strSql.Append("Content='" + model.content + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where Nid='" + model.nid + "' and Cid=" + model.cid + " ");
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
		public bool Delete(string nid,int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from novel_chapter_content ");
			strSql.Append(" where Nid='"+nid+"' and Cid="+cid+" " );
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
		public NovelManager.Model.novel_chapter_content GetModel(string nid,int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" base_id,Nid,Cid,Content ");
			strSql.Append(" from novel_chapter_content ");
			strSql.Append(" where Nid='"+nid+"' and Cid="+cid+" " );
			NovelManager.Model.novel_chapter_content model=new NovelManager.Model.novel_chapter_content();
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
				if(ds.Tables[0].Rows[0]["Cid"]!=null && ds.Tables[0].Rows[0]["Cid"].ToString()!="")
				{
					model.cid=int.Parse(ds.Tables[0].Rows[0]["Cid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Content"]!=null && ds.Tables[0].Rows[0]["Content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["Content"].ToString();
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
			strSql.Append("select base_id,Nid,Cid,Content ");
			strSql.Append(" FROM novel_chapter_content ");
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
			strSql.Append("select count(1) FROM novel_chapter_content ");
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
			strSql.Append(")AS Row, T.*  from novel_chapter_content T ");
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
	}
}

