///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the view 'V_GD_HOP_DONG_NOI_DUNG_TT'
// Generated by LLBLGen v1.21.2003.712 Final on: Monday, October 03, 2011, 10:51:38 AM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the view 'V_GD_HOP_DONG_NOI_DUNG_TT'.
	/// </summary>
	public class V_GD_HOP_DONG_NOI_DUNG_TT : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDecimal		_dON_GIA_HD, _iD_NOI_DUNG_TT, _sO_LUONG_HE_SO, _iD, _iD_HOP_DONG_KHUNG;
			private SqlString		_tEN_GIANG_VIEN, _sO_HOP_DONG, _nOI_DUNG_THANH_TOAN;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public V_GD_HOP_DONG_NOI_DUNG_TT()
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
		///		 <LI>ID_HOP_DONG_KHUNG</LI>
		///		 <LI>SO_HOP_DONG. May be SqlString.Null</LI>
		///		 <LI>TEN_GIANG_VIEN. May be SqlString.Null</LI>
		///		 <LI>ID_NOI_DUNG_TT</LI>
		///		 <LI>NOI_DUNG_THANH_TOAN. May be SqlString.Null</LI>
		///		 <LI>SO_LUONG_HE_SO</LI>
		///		 <LI>DON_GIA_HD</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_V_GD_HOP_DONG_NOI_DUNG_TT_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_HOP_DONG_KHUNG", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_HOP_DONG_KHUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_HOP_DONG", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_HOP_DONG));
				cmdToExecute.Parameters.Add(new SqlParameter("@TEN_GIANG_VIEN", SqlDbType.NVarChar, 101, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_GIANG_VIEN));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_NOI_DUNG_TT", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_NOI_DUNG_TT));
				cmdToExecute.Parameters.Add(new SqlParameter("@NOI_DUNG_THANH_TOAN", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nOI_DUNG_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_LUONG_HE_SO", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sO_LUONG_HE_SO));
				cmdToExecute.Parameters.Add(new SqlParameter("@DON_GIA_HD", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _dON_GIA_HD));
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
				throw new Exception("V_GD_HOP_DONG_NOI_DUNG_TT::Insert::Error occured.", ex);
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


		public SqlString SO_HOP_DONG
		{
			get
			{
				return _sO_HOP_DONG;
			}
			set
			{
				SqlString sO_HOP_DONGTmp = (SqlString)value;
				if(sO_HOP_DONGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_HOP_DONG", "SO_HOP_DONG can't be NULL");
				}
				_sO_HOP_DONG = value;
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


		public SqlDecimal ID_NOI_DUNG_TT
		{
			get
			{
				return _iD_NOI_DUNG_TT;
			}
			set
			{
				SqlDecimal iD_NOI_DUNG_TTTmp = (SqlDecimal)value;
				if(iD_NOI_DUNG_TTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_NOI_DUNG_TT", "ID_NOI_DUNG_TT can't be NULL");
				}
				_iD_NOI_DUNG_TT = value;
			}
		}


		public SqlString NOI_DUNG_THANH_TOAN
		{
			get
			{
				return _nOI_DUNG_THANH_TOAN;
			}
			set
			{
				SqlString nOI_DUNG_THANH_TOANTmp = (SqlString)value;
				if(nOI_DUNG_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NOI_DUNG_THANH_TOAN", "NOI_DUNG_THANH_TOAN can't be NULL");
				}
				_nOI_DUNG_THANH_TOAN = value;
			}
		}


		public SqlDecimal SO_LUONG_HE_SO
		{
			get
			{
				return _sO_LUONG_HE_SO;
			}
			set
			{
				SqlDecimal sO_LUONG_HE_SOTmp = (SqlDecimal)value;
				if(sO_LUONG_HE_SOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_LUONG_HE_SO", "SO_LUONG_HE_SO can't be NULL");
				}
				_sO_LUONG_HE_SO = value;
			}
		}


		public SqlDecimal DON_GIA_HD
		{
			get
			{
				return _dON_GIA_HD;
			}
			set
			{
				SqlDecimal dON_GIA_HDTmp = (SqlDecimal)value;
				if(dON_GIA_HDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DON_GIA_HD", "DON_GIA_HD can't be NULL");
				}
				_dON_GIA_HD = value;
			}
		}
		#endregion
	}
}