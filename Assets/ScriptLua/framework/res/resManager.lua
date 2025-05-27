---资源管理器
local resManager = {
    cache = {},  -- 资源缓存
    cacheBundle = {},  -- AssetBundle缓存
}

--- 获取资源
--- @param path string 资源路径
--- @param resType string 资源类型
--- @param abName string AssetBundle名称，默认为"Resources"

resManager.loadRes = function (path, resType,abName)
    abName = abName or "Resources"
    -- 优先查缓存
    if resManager.cache[abName] and resManager.cache[abName][path] then
        return resManager.cache[abName][path]
    end

    -- Resources加载
    if abName == "Resources" then
        local asset = CS.UnityEngine.Resources.Load(path)
        if asset then
            resManager.cache[abName] = resManager.cache[abName] or {}
            resManager.cache[abName][path] = asset
        end
        return asset
    else -- AssetBundle加载
        local ab = resManager.cacheBundle[abName] -- 检查AssetBundle缓存
        if not ab then 
            local ab = CS.UnityEngine.AssetBundle.LoadFromFile(abName)
            resManager.cacheBundle[abName] = ab
        end
        
        if ab then
            local asset = ab:LoadAsset(path)
            if asset then
                resManager.cache[abName] = resManager.cache[abName] or {}
                resManager.cache[abName][path] = asset
            end
            return asset
        else
            log("Error: AssetBundle not found: " .. abName)
            return nil
        end     
    end
end


--- 卸载bundle资源
--- @param abName string AssetBundle 
--- @param bUnload boolean 是否卸载所有已加载的对象
function resManager.unloadBundle(abName, bUnload)
    bUnload = bUnload or true
    local ab = resManager.cacheBundle[abName]
    if ab then
        ab:Unload(bUnload)
        resManager.cache[abName] = {}
        resManager.cacheBundle[abName] = nil
    else
        log("Error unload AssetBundle not found: " .. abName)
    end
end

--- 卸载所有Bundle资源
function resManager.unloadAllBundle()
    for abName, ab in pairs(resManager.cacheBundle) do
        ab:Unload(true)
    end
    resManager.cache[abName] = {}
    resManager.cacheBundle[abName] = nil
end

_G.resManager = resManager