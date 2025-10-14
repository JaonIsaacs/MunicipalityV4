using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalityV4.Models;

namespace MunicipalityV4.Services
{
    public static class IssueService
    {
        private static readonly LinkedList<Issue> _issues = new LinkedList<Issue>();
        private static readonly Stack<Issue> _deletedStack = new Stack<Issue>();

        public static void AddIssue(Issue issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            _issues.AddLast(issue);
        }

        public static IEnumerable<Issue> GetAllIssues()
        {
            // return a snapshot list to allow safe enumeration from UI
            return _issues.ToList();
        }

        public static Issue GetById(Guid id)
        {
            var node = _issues.First;
            while (node != null)
            {
                if (node.Value.Id == id) return node.Value;
                node = node.Next;
            }
            return null;
        }

        /// <summary>
        /// Update an existing issue; return true if succeeded.
        /// </summary>
        public static bool UpdateIssue(Issue updated)
        {
            if (updated == null) throw new ArgumentNullException(nameof(updated));
            var node = _issues.First;
            while (node != null)
            {
                if (node.Value.Id == updated.Id)
                {
                    node.Value.Location = updated.Location;
                    node.Value.Category = updated.Category;
                    node.Value.Description = updated.Description;
                    node.Value.Attachments = updated.Attachments ?? new List<string>();
                    node.Value.Status = updated.Status;
                    node.Value.SubmittedAt = updated.SubmittedAt;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        /// <summary>
        /// Delete issue by Id push onto deleted stack for undo. Returns true if deleted.
        /// </summary>
        public static bool DeleteIssue(Guid id)
        {
            var node = _issues.First;
            while (node != null)
            {
                if (node.Value.Id == id)
                {
                    _deletedStack.Push(node.Value);
                    _issues.Remove(node);
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        /// <summary>
        /// Undo last delete returns true if there was something to restore.
        /// </summary>
        public static bool UndoDelete()
        {
            if (_deletedStack.Count == 0) return false;
            var issue = _deletedStack.Pop();
            _issues.AddLast(issue);
            return true;
        }
    }
}

