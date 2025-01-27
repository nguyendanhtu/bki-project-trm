///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the view 'V_DM_NOI_DUNG_THANH_TOAN'
// Generated by LLBLGen v1.21.2003.712 Final on: Thursday, September 15, 2011, 10:48:58 AM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the view 'V_DM_NOI_DUNG_THANH_TOAN'.
	/// </summary>
	public class V_DM_NOI_DUNG_THANH_TOAN : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDecimal		_iD_LOAI_HOP_DONG, _dON_GIA_DEFAULT, _iD;
			private SqlString		_hOC_LIEU_YN, _vAN_HANH_YN, _tEN_NGAN, _mA_TU_DIEN, _tEN_NOI_DUNG, _gHI_CHU, _mA_TAN_SUAT, _mA_DON_VI_TINH;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public V_DM_NOI_DUNG_THANH_TOAN()
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
		///		 <LI>TEN_NOI_DUNG</LI>
		///		 <LI>GHI_CHU. May be SqlString.Null</LI>
		///		 <LI>ID_LOAI_HOP_DONG</LI>
		///		 <LI>MA_DON_VI_TINH. May be SqlString.Null</LI>
		///		 <LI>DON_GIA_DEFAULT. May be SqlDecimal.Null</LI>
		///		 <LI>MA_TAN_SUAT. May be SqlString.Null</LI>
		///		 <LI>HOC_LIEU_YN</LI>
		///		 <LI>VAN_HANH_YN</LI>
		///		 <LI>MA_TU_DIEN</LI>
		///		 <LI>TEN_NGAN</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_V_DM_NOI_DUNG_THANH_TOAN_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@TEN_NOI_DUNG", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_NOI_DUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@GHI_CHU", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _gHI_CHU));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_LOAI_HOP_DONG", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_LOAI_HOP_DONG));
				cmdToExecute.Parameters.Add(new SqlParameter("@MA_DON_VI_TINH", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mA_DON_VI_TINH));
				cmdToExecute.Parameters.Add(new SqlParameter("@DON_GIA_DEFAULT", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _dON_GIA_DEFAULT));
				cmdToExecute.Parameters.Add(new SqlParameter("@MA_TAN_SUAT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mA_TAN_SUAT));
				cmdToExecute.Parameters.Add(new SqlParameter("@HOC_LIEU_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _hOC_LIEU_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@VAN_HANH_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _vAN_HANH_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@MA_TU_DIEN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mA_TU_DIEN));
				cmdToExecute.Parameters.Add(new SqlParameter("@TEN_NGAN", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_NGAN));
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
				throw new Exception("V_DM_NOI_DUNG_THANH_TOAN::Insert::Error occured.", ex);
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


		public SqlString TEN_NOI_DUNG
		{
			get
			{
				return _tEN_NOI_DUNG;
			}
			set
			{
				SqlString tEN_NOI_DUNGTmp = (SqlString)value;
				if(tEN_NOI_DUNGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TEN_NOI_DUNG", "TEN_NOI_DUNG can't be NULL");
				}
				_tEN_NOI_DUNG = value;
			}
		}


		public SqlString GHI_CHU
		{
			get
			{
				return _gHI_CHU;
			}
			set
			{
				SqlString gHI_CHUTmp = (SqlString)value;
				if(gHI_CHUTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("GHI_CHU", "GHI_CHU can't be NULL");
				}
				_gHI_CHU = value;
			}
		}


		public SqlDecimal ID_LOAI_HOP_DONG
		{
			get
			{
				return _iD_LOAI_HOP_DONG;
			}
			set
			{
				SqlDecimal iD_LOAI_HOP_DONGTmp = (SqlDecimal)value;
				if(iD_LOAI_HOP_DONGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_LOAI_HOP_DONG", "ID_LOAI_HOP_DONG can't be NULL");
				}
				_iD_LOAI_HOP_DONG = value;
			}
		}


		public SqlString MA_DON_VI_TINH
		{
			get
			{
				return _mA_DON_VI_TINH;
			}
			set
			{
				SqlString mA_DON_VI_TINHTmp = (SqlString)value;
				if(mA_DON_VI_TINHTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MA_DON_VI_TINH", "MA_DON_VI_TINH can't be NULL");
				}
				_mA_DON_VI_TINH = value;
			}
		}


		public SqlDecimal DON_GIA_DEFAULT
		{
			get
			{
				return _dON_GIA_DEFAULT;
			}
			set
			{
				SqlDecimal dON_GIA_DEFAULTTmp = (SqlDecimal)value;
				if(dON_GIA_DEFAULTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DON_GIA_DEFAULT", "DON_GIA_DEFAULT can't be NULL");
				}
				_dON_GIA_DEFAULT = value;
			}
		}


		public SqlString MA_TAN_SUAT
		{
			get
			{
				return _mA_TAN_SUAT;
			}
			set
			{
				SqlString mA_TAN_SUATTmp = (SqlString)value;
				if(mA_TAN_SUATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MA_TAN_SUAT", "MA_TAN_SUAT can't be NULL");
				}
				_mA_TAN_SUAT = value;
			}
		}


		public SqlString HOC_LIEU_YN
		{
			get
			{
				return _hOC_LIEU_YN;
			}
			set
			{
				SqlString hOC_LIEU_YNTmp = (SqlString)value;
				if(hOC_LIEU_YNTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("HOC_LIEU_YN", "HOC_LIEU_YN can't be NULL");
				}
				_hOC_LIEU_YN = value;
			}
		}


		public SqlString VAN_HANH_YN
		{
			get
			{
				return _vAN_HANH_YN;
			}
			set
			{
				SqlString vAN_HANH_YNTmp = (SqlString)value;
				if(vAN_HANH_YNTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("VAN_HANH_YN", "VAN_HANH_YN can't be NULL");
				}
				_vAN_HANH_YN = value;
			}
		}


		public SqlString MA_TU_DIEN
		{
			get
			{
				return _mA_TU_DIEN;
			}
			set
			{
				SqlString mA_TU_DIENTmp = (SqlString)value;
				if(mA_TU_DIENTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MA_TU_DIEN", "MA_TU_DIEN can't be NULL");
				}
				_mA_TU_DIEN = value;
			}
		}


		public SqlString TEN_NGAN
		{
			get
			{
				return _tEN_NGAN;
			}
			set
			{
				SqlString tEN_NGANTmp = (SqlString)value;
				if(tEN_NGANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TEN_NGAN", "TEN_NGAN can't be NULL");
				}
				_tEN_NGAN = value;
			}
		}
		#endregion
	}
}
