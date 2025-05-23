

--[[
   @desc: 获取按钮组件
   @param: obj 按钮对象
   @return: 按钮组件
]]
function GoGetButton(obj)
   if obj == nil then
      return
   end

   local btn = obj:GetComponent(typeof(UEUI.Button))
   return btn
end

--[[
   @desc: 获取组件
   @param: obj 
   @return: 组件
]]
function GoGetComponent(obj,tp)
    if obj~=nil then
        return obj:GetComponent(tp)
    end
    return nil
end
--[[
   @desc: 添加按钮点击事件
   @param: obj 按钮对象
   @param: callBack 点击事件函数
]]
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

--[[
   @desc: 获取组件上面挂的对象
   @param: obj 
   @return: 
]]
function getObjHolder(obj)
    local holder = GoGetComponent(obj,typeof(LU.GameObjectHolder))
    if holder ~= nil then
        local tab = {}
        holder:GetObjectsWithTab(tab)
        return tab,holder
    end
    return nil
    
end