-- Audio Manager Module
local audioManager = {}


--- 播放音效
-- @param audioName 音效名称
-- @param loop 是否循环播放
-- @param volume 音量
audioManager.playEffect = function(audioName,loop, volume)

end


--- 停止音效
-- @param audioName 音效名称
audioManager.stopEffect = function(audioName)

end

--- 设置音效音量
--- @param volume 音量
audioManager.setEffectVolume = function(volume)

end

--- 播放背景音效
--- @param audioName 音乐名称
--- @param loop 是否循环播放
--- @param volume 音量

audioManager.playMusic = function(audioName,loop, volume)

end

--- 停止背景音效
--- @param audioName 音乐名称
audioManager.stopMusic = function(audioName)

end

---设置背景音效音量
--- @param volume 音量
audioManager.setMusicVolume = function(volume)
    
end



_G.audioManager = audioManager