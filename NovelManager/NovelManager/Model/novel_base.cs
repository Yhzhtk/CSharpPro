using System;
namespace NovelManager.Model
{
	/// <summary>
	/// novel_base:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class novel_base
	{
		public novel_base()
		{}
		#region Model
		private long _id;
		private string _nid;
		private string _name;
		private string _author;
		private int _chaptercount=0;
		private int _blankchapter_type=0;
		private int _blankchapter_count=0;
		private int _novelstate=0;
		private string _type;
		private int _no_desc=0;
		private int _state=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int chaptercount
		{
			set{ _chaptercount=value;}
			get{return _chaptercount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int blankchapter_type
		{
			set{ _blankchapter_type=value;}
			get{return _blankchapter_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int blankchapter_count
		{
			set{ _blankchapter_count=value;}
			get{return _blankchapter_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int novelstate
		{
			set{ _novelstate=value;}
			get{return _novelstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int no_desc
		{
			set{ _no_desc=value;}
			get{return _no_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

