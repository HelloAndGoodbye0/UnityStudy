DEBUG = 1 --是否是调试模式  0关闭 1开启

--- 日志输出函数
---@param info string 日志信息
---@param ... any 其他参数
log = function(info, ...)
    if DEBUG == 1 then
        print(info, ...)
    end
end
