// <copyright file="TaskConstants.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace WootzJs.Mvc.Utils
{
    public class TaskConstants
    {
        public static readonly Task Completed = Task.FromResult<object>(null);
    }
}