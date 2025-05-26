
--[[
事件中心
]]

local eventManager = {
    events = {}
}

--- 添加事件
---@param eventName any
---@param ... any
eventManager.on = function(eventName, callback)
    if not eventManager.events[eventName] then
        eventManager.events[eventName] = {}
    end
    table.insert(eventManager.events[eventName], callback)
end

---移除事件
---@param eventName any
---@param callback any
eventManager.off = function(eventName, callback)
    if not eventManager.events[eventName] then
        return
    end
    for i, cb in ipairs(eventManager.events[eventName]) do
        if cb == callback then
            table.remove(eventManager.events[eventName], i)
            break
        end
    end
end



--- 触发事件
---@param eventName any
---@param ... unknown
eventManager.emit = function(eventName, ...)
    if not eventManager.events[eventName] then
        return
    end
    for _, callback in ipairs(eventManager.events[eventName]) do
        callback(...)
    end
end

_G.EventManager = eventManager