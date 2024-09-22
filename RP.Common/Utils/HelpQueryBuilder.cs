using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Common.Utils
{
    public class HelpQueryBuilder
    {
        private readonly StringBuilder _stringBuilder;
        private readonly List<object> _parameters;

        public HelpQueryBuilder()
        {
            _stringBuilder = new StringBuilder();
            _parameters = new List<object>();
        }

        public void Select(params string[] columns)
        {
            _stringBuilder.Append("SELECT ");
            _stringBuilder.AppendJoin(",", columns.Select(c => $@"{c}"));
        }

        public void From(string schema, string table, string alias)
        {
            _stringBuilder.Append(" FROM ");
            _stringBuilder.Append($@"""{schema}"".""{table}"" AS {alias}");
        }

        public void Join(string schema, string table, string alias, string onClause)
        {
            _stringBuilder.Append(" JOIN ");
            if (!string.IsNullOrEmpty(schema))
            {
                _stringBuilder.Append($@"""{schema}"".");
            }
            _stringBuilder.Append($@"""{table}"" AS {alias} ON {onClause}");
        }

        public void InnerJoin(string schema, string table, string alias, string onClause)
        {
            _stringBuilder.Append(" INNER JOIN ");
            if (!string.IsNullOrEmpty(schema))
            {
                _stringBuilder.Append($@"""{schema}"".");
            }
            _stringBuilder.Append($@"""{table}"" AS {alias} ON {onClause}");
        }

        public void LeftJoin(string schema, string table, string alias, string onClause)
        {
            _stringBuilder.Append(" LEFT JOIN ");
            if (!string.IsNullOrEmpty(schema))
            {
                _stringBuilder.Append($@"""{schema}"".");
            }
            _stringBuilder.Append($@"""{table}"" AS {alias} ON {onClause}");
        }

        public void Where(string condition, params object[] values)
        {
            _stringBuilder.Append(" WHERE ");
            _stringBuilder.Append(condition);
            _parameters.AddRange(values);
        }

        public void And(string condition, params object[] values)
        {
            _stringBuilder.Append(" AND ");
            _stringBuilder.Append(condition);
            _parameters.AddRange(values);
        }

        public void GroupBy(params string[] columns)
        {
            _stringBuilder.Append(" GROUP BY ");
            _stringBuilder.AppendJoin(",", columns.Select(c => $@"{c}"));
        }

        public void OrderBy(string column, string direction = "DESC")
        {
            _stringBuilder.Append(" ORDER BY ");
            _stringBuilder.Append($@"{column} {direction} ");
        }

        public void Limit(int limit)
        {
            _stringBuilder.Append($" LIMIT {limit} ");
        }

        public void With(string alias, string cteQuery)
        {
            _stringBuilder.Append("WITH ");
            _stringBuilder.Append(alias);
            _stringBuilder.Append(" AS (");
            _stringBuilder.Append(cteQuery);
            _stringBuilder.Append(") ");
        }

        public void Append(string query)
        {
            _stringBuilder.Append(query);
        }

        public void AppendJoin(params string[] columns)
        {
            _stringBuilder.AppendJoin(",", columns.Select(c => $@"{c}"));
        }

        public string Build(params object[] additionalParameters)
        {
            _parameters.AddRange(additionalParameters);
            if (_parameters != null && _parameters.Count() > 0)
            {
                return String.Format(_stringBuilder.ToString(), _parameters.ToArray());
            }
            return _stringBuilder.ToString();
        }
    }
}
