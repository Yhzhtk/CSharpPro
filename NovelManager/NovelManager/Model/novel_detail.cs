using System;
namespace NovelManager.Model
{
	/// <summary>
	/// novel_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class novel_detail
	{
		public novel_detail()
		{}
		#region Model
		private long _base_id;
		private string _nid;
		private string _url;
		private int _click=0;
		private int _recommend=0;
		private string _updatedate;
		private string _description;
		private string _sourcesite;
		private string _chapter;
		private string _blank_chapter;
		private string _cover_image;
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
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int recommend
		{
			set{ _recommend=value;}
			get{return _recommend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sourcesite
		{
			set{ _sourcesite=value;}
			get{return _sourcesite;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chapter
		{
			set{ _chapter=value;}
			get{return _chapter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string blank_chapter
		{
			set{ _blank_chapter=value;}
			get{return _blank_chapter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cover_image
		{
			set{ _cover_image=value;}
			get{return _cover_image;}
		}
		#endregion Model

	}
}

