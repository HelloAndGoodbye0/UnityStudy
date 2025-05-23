DEBUG = 1 --是否是调试模式  0关闭 1开启

--[[
    日志打印
    @param info 日志信息
]]
DLG = function(info, ...)
    if DEBUG == 1 then
        print(info, ...)
    end
end