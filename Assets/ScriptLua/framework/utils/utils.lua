

---获取按钮
---@param obj 对象
---@return UEUI.Button|nil 返回按钮组件，如果对象为nil或没有按钮组件则返回nil
function GoGetButton(obj)
   if obj == nil then
      return nil
   end
   local btn = obj:GetComponent(typeof(UEUI.Button))
   return btn
end


---@param obj 对象
---@param tp 组件类型
function GoGetComponent(obj,tp)
    if obj~=nil then
        return obj:GetComponent(tp)
    end
    return nil
end

---添加按钮点击事件
---@param obj 按钮对象
---@param callBack 回调函数
function addBtnClick(obj, callBack)
   if obj == nil then
      return
   end
   local btn = GoGetButton(obj)
   if btn ~= nil then
      btn.onClick:AddListener(function()
        --TODO 播放通用音效
         if callBack ~= nil then
            callBack(btn)
         end
      end)
   end
end

---获取对象Holder
---@param obj 对象
---@return table|nil 返回对象Holder中的对象列表和Holder组件
function getObjHolder(obj)
    local holder = GoGetComponent(obj,typeof(LU.GameObjectHolder))
    if holder ~= nil then
        local tab = {}
        holder:GetObjectsWithTab(tab)
        return tab,holder
    end
    return nil
    
end