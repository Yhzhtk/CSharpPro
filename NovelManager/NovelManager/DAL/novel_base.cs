using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using DBUtility;//Please add references
namespace NovelManager.DAL
{
	/// <summary>
	/// 数据访问类:novel_base
	/// </summary>
	public partial class novel_base
	{
		public novel_base()
		{}

		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from novel_base");
			strSql.Append(" where id="+id+" ");
			return DbHelperMySQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(NovelManager.Model.novel_base model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.nid != null)
            {
                strSql1.Append("Nid,");
                strSql2.Append("'" + model.nid + "',");
            }
            if (model.name != null)
            {
                strSql1.Append("name,");
                strSql2.Append("'" + model.name + "',");
            }
            if (model.author != null)
            {
                strSql1.Append("author,");
                strSql2.Append("'" + model.author + "',");
            }

            strSql1.Append("chaptercount,");
            strSql2.Append("" + model.chaptercount + ",");


            strSql1.Append("blankchapter_type,");
            strSql2.Append("" + model.blankchapter_type + ",");

            strSql1.Append("blankchapter_count,");
            strSql2.Append("" + model.blankchapter_count + ",");


            strSql1.Append("novelstate,");
            strSql2.Append("" + model.novelstate + ",");

            if (model.type != null)
            {
                strSql1.Append("type,");
                strSql2.Append("'" + model.type + "',");
            }

            strSql1.Append("no_desc,");
            strSql2.Append("" + model.no_desc + ",");


            strSql1.Append("state,");
            strSql2.Append("" + model.state + ",");

            strSql.Append("insert into novel_base(");
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
        public bool Update(NovelManager.Model.novel_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update novel_base set ");
            if (model.nid != null)
            {
                strSql.Append("Nid='" + model.nid + "',");
            }
            if (model.name != null)
            {
                strSql.Append("name='" + model.name + "',");
            }
            if (model.author != null)
            {
                strSql.Append("author='" + model.author + "',");
            }

            strSql.Append("chaptercount=" + model.chaptercount + ",");


            strSql.Append("blankchapter_type=" + model.blankchapter_type + ",");


            strSql.Append("blankchapter_count=" + model.blankchapter_count + ",");


            strSql.Append("novelstate=" + model.novelstate + ",");

            if (model.type != null)
            {
                strSql.Append("type='" + model.type + "',");
            }

            strSql.Append("no_desc=" + model.no_desc + ",");


            strSql.Append("state=" + model.state + ",");

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + "");
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
		public bool Delete(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from novel_base ");
			strSql.Append(" where id="+id+"" );
			int rowsAffected=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from novel_base ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public NovelManager.Model.novel_base GetModel(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,Nid,name,author,chaptercount,blankchapter_type,blankchapter_count,novelstate,type,no_desc,state ");
			strSql.Append(" from novel_base ");
			strSql.Append(" where id="+id+"" );
			NovelManager.Model.novel_base model=new NovelManager.Model.novel_base();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Nid"]!=null && ds.Tables[0].Rows[0]["Nid"].ToString()!="")
				{
					model.nid=ds.Tables[0].Rows[0]["Nid"].ToString();
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["author"]!=null && ds.Tables[0].Rows[0]["author"].ToString()!="")
				{
					model.author=ds.Tables[0].Rows[0]["author"].ToString();
				}
				if(ds.Tables[0].Rows[0]["chaptercount"]!=null && ds.Tables[0].Rows[0]["chaptercount"].ToString()!="")
				{
					model.chaptercount=int.Parse(ds.Tables[0].Rows[0]["chaptercount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["blankchapter_type"]!=null && ds.Tables[0].Rows[0]["blankchapter_type"].ToString()!="")
				{
					model.blankchapter_type=int.Parse(ds.Tables[0].Rows[0]["blankchapter_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["blankchapter_count"]!=null && ds.Tables[0].Rows[0]["blankchapter_count"].ToString()!="")
				{
					model.blankchapter_count=int.Parse(ds.Tables[0].Rows[0]["blankchapter_count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["novelstate"]!=null && ds.Tables[0].Rows[0]["novelstate"].ToString()!="")
				{
					model.novelstate=int.Parse(ds.Tables[0].Rows[0]["novelstate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["no_desc"]!=null && ds.Tables[0].Rows[0]["no_desc"].ToString()!="")
				{
					model.no_desc=int.Parse(ds.Tables[0].Rows[0]["no_desc"].ToString());
				}
				if(ds.Tables[0].Rows[0]["state"]!=null && ds.Tables[0].Rows[0]["state"].ToString()!="")
				{
					model.state=int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
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
			strSql.Append("select id,Nid,name,author,chaptercount,blankchapter_type,blankchapter_count,novelstate,type,no_desc,state ");
			strSql.Append(" FROM novel_base ");
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
			strSql.Append("select count(1) FROM novel_base ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from novel_base T ");
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

        #region  自写方法
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
        /// 得到一个对象实体
        /// </summary>
        public NovelManager.Model.novel_base GetModelFromNid(string nid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" id,Nid,name,author,chaptercount,blankchapter_type,blankchapter_count,novelstate,type,no_desc,state ");
            strSql.Append(" from novel_base ");
            strSql.Append(" where Nid='" + nid + "'");
            NovelManager.Model.novel_base model = new NovelManager.Model.novel_base();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Nid"] != null && ds.Tables[0].Rows[0]["Nid"].ToString() != "")
                {
                    model.nid = ds.Tables[0].Rows[0]["Nid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["author"] != null && ds.Tables[0].Rows[0]["author"].ToString() != "")
                {
                    model.author = ds.Tables[0].Rows[0]["author"].ToString();
                }
                if (ds.Tables[0].Rows[0]["chaptercount"] != null && ds.Tables[0].Rows[0]["chaptercount"].ToString() != "")
                {
                    model.chaptercount = int.Parse(ds.Tables[0].Rows[0]["chaptercount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["blankchapter_type"] != null && ds.Tables[0].Rows[0]["blankchapter_type"].ToString() != "")
                {
                    model.blankchapter_type = int.Parse(ds.Tables[0].Rows[0]["blankchapter_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["blankchapter_count"] != null && ds.Tables[0].Rows[0]["blankchapter_count"].ToString() != "")
                {
                    model.blankchapter_count = int.Parse(ds.Tables[0].Rows[0]["blankchapter_count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["novelstate"] != null && ds.Tables[0].Rows[0]["novelstate"].ToString() != "")
                {
                    model.novelstate = int.Parse(ds.Tables[0].Rows[0]["novelstate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type"] != null && ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = ds.Tables[0].Rows[0]["type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["no_desc"] != null && ds.Tables[0].Rows[0]["no_desc"].ToString() != "")
                {
                    model.no_desc = int.Parse(ds.Tables[0].Rows[0]["no_desc"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

	    #endregion  Method

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

