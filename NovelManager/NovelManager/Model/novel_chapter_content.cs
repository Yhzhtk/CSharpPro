using System;
namespace NovelManager.Model
{
	/// <summary>
	/// novel_chapter_content:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class novel_chapter_content
	{
		public novel_chapter_content()
		{}
		#region Model
		private long _base_id;
		private string _nid;
		private int _cid;
		private string _content;
		/// <summary>
		/// 
		/// </summary>
		public long base_id
		{
			set{ _base_id=value;}
			get{return _base_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nid
		{
			set{ _nid=value;}
			get{return _nid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

