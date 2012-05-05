///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the view 'V_GD_THANH_TOAN'
// Generated by LLBLGen v1.21.2003.712 Final on: Wednesday, November 16, 2011, 3:57:16 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the view 'V_GD_THANH_TOAN'.
	/// </summary>
	public class V_GD_THANH_TOAN : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_nGAY_THANH_TOAN;
			private SqlDecimal		_iD_TRANG_THAI_THANH_TOAN, _iD_MON_HOC, _tONG_TIEN_THUC_NHAN, _sO_TIEN_THUE, _tONG_TIEN_THANH_TOAN, _iD_GIANG_VIEN, _iD, _iD_HOP_DONG_KHUNG;
			private SqlString		_rEFERENCE_CODE, _sO_PHIEU_THANH_TOAN, _sO_TAI_KHOAN, _tEN_NGAN_HANG, _dESCRIPTION, _tEN_GIANG_VIEN;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public V_GD_THANH_TOAN()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>SO_PHIEU_THANH_TOAN</LI>
		///		 <LI>ID_HOP_DONG_KHUNG</LI>
		///		 <LI>ID_GIANG_VIEN</LI>
		///		 <LI>TEN_GIANG_VIEN</LI>
		///		 <LI>SO_TAI_KHOAN. May be SqlString.Null</LI>
		///		 <LI>TEN_NGAN_HANG. May be SqlString.Null</LI>
		///		 <LI>REFERENCE_CODE. May be SqlString.Null</LI>
		///		 <LI>ID_MON_HOC</LI>
		///		 <LI>NGAY_THANH_TOAN</LI>
		///		 <LI>DESCRIPTION. May be SqlString.Null</LI>
		///		 <LI>TONG_TIEN_THANH_TOAN</LI>
		///		 <LI>SO_TIEN_THUE</LI>
		///		 <LI>TONG_TIEN_THUC_NHAN</LI>
		///		 <LI>ID_TRANG_THAI_THANH_TOAN</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_V_GD_THANH_TOAN_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_PHIEU_THANH_TOAN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_PHIEU_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_HOP_DONG_KHUNG", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_HOP_DONG_KHUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_GIANG_VIEN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_GIANG_VIEN));
				cmdToExecute.Parameters.Add(new SqlParameter("@TEN_GIANG_VIEN", SqlDbType.NVarChar, 101, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_GIANG_VIEN));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_TAI_KHOAN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_TAI_KHOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@TEN_NGAN_HANG", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_NGAN_HANG));
				cmdToExecute.Parameters.Add(new SqlParameter("@REFERENCE_CODE", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEFERENCE_CODE));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_MON_HOC", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_MON_HOC));
				cmdToExecute.Parameters.Add(new SqlParameter("@NGAY_THANH_TOAN", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nGAY_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dESCRIPTION));
				cmdToExecute.Parameters.Add(new SqlParameter("@TONG_TIEN_THANH_TOAN", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tONG_TIEN_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_TIEN_THUE", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sO_TIEN_THUE));
				cmdToExecute.Parameters.Add(new SqlParameter("@TONG_TIEN_THUC_NHAN", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tONG_TIEN_THUC_NHAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_TRANG_THAI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _iD));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_iD = (Decimal)cmdToExecute.Parameters["@ID"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("V_GD_THANH_TOAN::Insert::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		#region Class Property Declarations
		public SqlDecimal ID
		{
			get
			{
				return _iD;
			}
			set
			{
				SqlDecimal iDTmp = (SqlDecimal)value;
				if(iDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
				}
				_iD = value;
			}
		}


		public SqlString SO_PHIEU_THANH_TOAN
		{
			get
			{
				return _sO_PHIEU_THANH_TOAN;
			}
			set
			{
				SqlString sO_PHIEU_THANH_TOANTmp = (SqlString)value;
				if(sO_PHIEU_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_PHIEU_THANH_TOAN", "SO_PHIEU_THANH_TOAN can't be NULL");
				}
				_sO_PHIEU_THANH_TOAN = value;
			}
		}


		public SqlDecimal ID_HOP_DONG_KHUNG
		{
			get
			{
				return _iD_HOP_DONG_KHUNG;
			}
			set
			{
				SqlDecimal iD_HOP_DONG_KHUNGTmp = (SqlDecimal)value;
				if(iD_HOP_DONG_KHUNGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_HOP_DONG_KHUNG", "ID_HOP_DONG_KHUNG can't be NULL");
				}
				_iD_HOP_DONG_KHUNG = value;
			}
		}


		public SqlDecimal ID_GIANG_VIEN
		{
			get
			{
				return _iD_GIANG_VIEN;
			}
			set
			{
				SqlDecimal iD_GIANG_VIENTmp = (SqlDecimal)value;
				if(iD_GIANG_VIENTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_GIANG_VIEN", "ID_GIANG_VIEN can't be NULL");
				}
				_iD_GIANG_VIEN = value;
			}
		}


		public SqlString TEN_GIANG_VIEN
		{
			get
			{
				return _tEN_GIANG_VIEN;
			}
			set
			{
				SqlString tEN_GIANG_VIENTmp = (SqlString)value;
				if(tEN_GIANG_VIENTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TEN_GIANG_VIEN", "TEN_GIANG_VIEN can't be NULL");
				}
				_tEN_GIANG_VIEN = value;
			}
		}


		public SqlString SO_TAI_KHOAN
		{
			get
			{
				return _sO_TAI_KHOAN;
			}
			set
			{
				SqlString sO_TAI_KHOANTmp = (SqlString)value;
				if(sO_TAI_KHOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_TAI_KHOAN", "SO_TAI_KHOAN can't be NULL");
				}
				_sO_TAI_KHOAN = value;
			}
		}


		public SqlString TEN_NGAN_HANG
		{
			get
			{
				return _tEN_NGAN_HANG;
			}
			set
			{
				SqlString tEN_NGAN_HANGTmp = (SqlString)value;
				if(tEN_NGAN_HANGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TEN_NGAN_HANG", "TEN_NGAN_HANG can't be NULL");
				}
				_tEN_NGAN_HANG = value;
			}
		}


		public SqlString REFERENCE_CODE
		{
			get
			{
				return _rEFERENCE_CODE;
			}
			set
			{
				SqlString rEFERENCE_CODETmp = (SqlString)value;
				if(rEFERENCE_CODETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REFERENCE_CODE", "REFERENCE_CODE can't be NULL");
				}
				_rEFERENCE_CODE = value;
			}
		}


		public SqlDecimal ID_MON_HOC
		{
			get
			{
				return _iD_MON_HOC;
			}
			set
			{
				SqlDecimal iD_MON_HOCTmp = (SqlDecimal)value;
				if(iD_MON_HOCTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_MON_HOC", "ID_MON_HOC can't be NULL");
				}
				_iD_MON_HOC = value;
			}
		}


		public SqlDateTime NGAY_THANH_TOAN
		{
			get
			{
				return _nGAY_THANH_TOAN;
			}
			set
			{
				SqlDateTime nGAY_THANH_TOANTmp = (SqlDateTime)value;
				if(nGAY_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NGAY_THANH_TOAN", "NGAY_THANH_TOAN can't be NULL");
				}
				_nGAY_THANH_TOAN = value;
			}
		}


		public SqlString DESCRIPTION
		{
			get
			{
				return _dESCRIPTION;
			}
			set
			{
				SqlString dESCRIPTIONTmp = (SqlString)value;
				if(dESCRIPTIONTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DESCRIPTION", "DESCRIPTION can't be NULL");
				}
				_dESCRIPTION = value;
			}
		}


		public SqlDecimal TONG_TIEN_THANH_TOAN
		{
			get
			{
				return _tONG_TIEN_THANH_TOAN;
			}
			set
			{
				SqlDecimal tONG_TIEN_THANH_TOANTmp = (SqlDecimal)value;
				if(tONG_TIEN_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TONG_TIEN_THANH_TOAN", "TONG_TIEN_THANH_TOAN can't be NULL");
				}
				_tONG_TIEN_THANH_TOAN = value;
			}
		}


		public SqlDecimal SO_TIEN_THUE
		{
			get
			{
				return _sO_TIEN_THUE;
			}
			set
			{
				SqlDecimal sO_TIEN_THUETmp = (SqlDecimal)value;
				if(sO_TIEN_THUETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_TIEN_THUE", "SO_TIEN_THUE can't be NULL");
				}
				_sO_TIEN_THUE = value;
			}
		}


		public SqlDecimal TONG_TIEN_THUC_NHAN
		{
			get
			{
				return _tONG_TIEN_THUC_NHAN;
			}
			set
			{
				SqlDecimal tONG_TIEN_THUC_NHANTmp = (SqlDecimal)value;
				if(tONG_TIEN_THUC_NHANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TONG_TIEN_THUC_NHAN", "TONG_TIEN_THUC_NHAN can't be NULL");
				}
				_tONG_TIEN_THUC_NHAN = value;
			}
		}


		public SqlDecimal ID_TRANG_THAI_THANH_TOAN
		{
			get
			{
				return _iD_TRANG_THAI_THANH_TOAN;
			}
			set
			{
				SqlDecimal iD_TRANG_THAI_THANH_TOANTmp = (SqlDecimal)value;
				if(iD_TRANG_THAI_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_TRANG_THAI_THANH_TOAN", "ID_TRANG_THAI_THANH_TOAN can't be NULL");
				}
				_iD_TRANG_THAI_THANH_TOAN = value;
			}
		}
		#endregion
	}
}