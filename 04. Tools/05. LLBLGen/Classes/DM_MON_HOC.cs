///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'DM_MON_HOC'
// Generated by LLBLGen v1.21.2003.712 Final on: Saturday, September 17, 2011, 12:20:04 AM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'DM_MON_HOC'.
	/// </summary>
	public class DM_MON_HOC : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDecimal		_sO_DVHT, _iD;
			private SqlString		_gHI_CHU, _mA_MON_HOC, _tEN_MON_HOC;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public DM_MON_HOC()
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
		///		 <LI>MA_MON_HOC</LI>
		///		 <LI>TEN_MON_HOC</LI>
		///		 <LI>SO_DVHT. May be SqlDecimal.Null</LI>
		///		 <LI>GHI_CHU. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_MON_HOC_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sMA_MON_HOC", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mA_MON_HOC));
				cmdToExecute.Parameters.Add(new SqlParameter("@sTEN_MON_HOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_MON_HOC));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcSO_DVHT", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 4, 1, "", DataRowVersion.Proposed, _sO_DVHT));
				cmdToExecute.Parameters.Add(new SqlParameter("@sGHI_CHU", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _gHI_CHU));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID", SqlDbType.Decimal, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _iD));

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
				_iD = (Decimal)cmdToExecute.Parameters["@dcID"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DM_MON_HOC::Insert::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		///		 <LI>MA_MON_HOC</LI>
		///		 <LI>TEN_MON_HOC</LI>
		///		 <LI>SO_DVHT. May be SqlDecimal.Null</LI>
		///		 <LI>GHI_CHU. May be SqlString.Null</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_MON_HOC_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));
				cmdToExecute.Parameters.Add(new SqlParameter("@sMA_MON_HOC", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mA_MON_HOC));
				cmdToExecute.Parameters.Add(new SqlParameter("@sTEN_MON_HOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_MON_HOC));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcSO_DVHT", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 4, 1, "", DataRowVersion.Proposed, _sO_DVHT));
				cmdToExecute.Parameters.Add(new SqlParameter("@sGHI_CHU", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _gHI_CHU));

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
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DM_MON_HOC::Update::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_MON_HOC_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));

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
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("DM_MON_HOC::Delete::Error occured.", ex);
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


		public SqlString MA_MON_HOC
		{
			get
			{
				return _mA_MON_HOC;
			}
			set
			{
				SqlString mA_MON_HOCTmp = (SqlString)value;
				if(mA_MON_HOCTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MA_MON_HOC", "MA_MON_HOC can't be NULL");
				}
				_mA_MON_HOC = value;
			}
		}


		public SqlString TEN_MON_HOC
		{
			get
			{
				return _tEN_MON_HOC;
			}
			set
			{
				SqlString tEN_MON_HOCTmp = (SqlString)value;
				if(tEN_MON_HOCTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TEN_MON_HOC", "TEN_MON_HOC can't be NULL");
				}
				_tEN_MON_HOC = value;
			}
		}


		public SqlDecimal SO_DVHT
		{
			get
			{
				return _sO_DVHT;
			}
			set
			{
				SqlDecimal sO_DVHTTmp = (SqlDecimal)value;
				if(sO_DVHTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_DVHT", "SO_DVHT can't be NULL");
				}
				_sO_DVHT = value;
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
		#endregion
	}
}