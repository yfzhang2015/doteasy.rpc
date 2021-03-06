﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotEasy.Rpc.Core.Routing.Impl;

namespace DotEasy.Rpc.Core.Routing
{
    /// <summary>
    /// 抽象的服务路由发现者
    /// </summary>
    public interface IServiceRouteManager
    {
        /// <summary>
        /// 服务路由被创建
        /// </summary>
        event EventHandler<ServiceRouteEventArgs> Created;

        /// <summary>
        /// 服务路由被删除
        /// </summary>
        event EventHandler<ServiceRouteEventArgs> Removed;

        /// <summary>
        /// 服务路由被修改
        /// </summary>
        event EventHandler<ServiceRouteChangedEventArgs> Changed;

        /// <summary>
        /// 获取所有可用的服务路由信息
        /// </summary>
        /// <returns>服务路由集合</returns>
        Task<IEnumerable<ServiceRoute>> GetRoutesAsync();

        /// <summary>
        /// 设置服务路由
        /// </summary>
        /// <param name="routes">服务路由集合</param>
        /// <returns>一个任务</returns>
        Task SetRoutesAsync(IEnumerable<ServiceRoute> routes);

        /// <summary>
        /// 清空所有的服务路由
        /// </summary>
        /// <returns>一个任务</returns>
        Task ClearAsync();
    }
}