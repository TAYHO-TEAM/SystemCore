﻿using Dapper;
using Dapper.Common;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Repositories
{
    public class NS_NhomCongViecRepository<T> : INS_NhomCongViecRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public NS_NhomCongViecRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public async Task<PagingItems<T>> GetNhomCongViec_NhomCongViecDetailAsync(RequestTreeListBaseFilterParam requestBaseFilterParam)
        {
            requestBaseFilterParam.ColumName = requestBaseFilterParam.ColumName ?? "*";
            var result = new PagingItems<T>
            {
                PagingInfo = new PagingInfo
                {
                    PageNumber = requestBaseFilterParam.PageNumber,
                    PageSize = requestBaseFilterParam.PageSize
                }
            };
            using var conn = await _connectionFactory.CreateConnectionAsync();
            using var rs = conn.QueryMultipleAsync("sp_NhomCongViec_NhomCongViecDetail", requestBaseFilterParam, commandType: CommandType.StoredProcedure).Result;
            result.PagingInfo.TotalItems = await rs.ReadSingleAsync<int>().ConfigureAwait(false);
            result.Items = await rs.ReadAsync<T>().ConfigureAwait(false);

            return result;
        }
    }
}