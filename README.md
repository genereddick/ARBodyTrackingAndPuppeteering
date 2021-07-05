# ARBodyTrackingAndPuppeteering
 Control an avatar synced to an Unity AR Foundation body tracking controlled robot

 <p>
Body Tracking with ARKit works very well as does the Unity integration into AR Foundation. However, the rig that <a href="https://developer.apple.com/documentation/arkit/content_anchors/rigging_a_model_for_motion_capture">Apple provides</a>, as well as the version Unity includes in their <a href="https://github.com/Unity-Technologies/arfoundation-samples">sample project</a> have some complexities that have made working with them challenging. 
</p>

<p>
While initially I had thought to replace the sample controlled robot model I found it difficult. The ARKit rig is not like other rigs (7 spine bones, 4 neck bones, different orientations, etc.) in common usage. The Unity version has no avatar associated with it so you are unable to access some of the built in HumanBones and retargeting functionality normally available. Attempts to rig my own  version failed for various reasons. 
 </p>
 
 <p>
 My solution was to keep the controlled robot and pair its movements to a second avatar and, if desired, overlay the positions and hide the controlled robot. 
</p>

<p>Here I'm connecting the armature from the recently updated <a href="https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526">3rd Person Unity Starter Assets</a> to the AR Foundation samples ControlledRobot asset.
</p>


<div class="separator" style="clear: both;"><a href="https://1.bp.blogspot.com/-AcD3Ilh-JAg/YMRRK6eynlI/AAAAAAAAgOE/N2p33gLzIBAEekHkjG9LQH0ED85uThbuACLcBGAsYHQ/s1245/Screenshot%2B2021-06-11%2B231550.png" style="display: block; padding: 1em 0; text-align: center; "><img alt="" border="0" width="320" data-original-height="961" data-original-width="1245" src="https://1.bp.blogspot.com/-AcD3Ilh-JAg/YMRRK6eynlI/AAAAAAAAgOE/N2p33gLzIBAEekHkjG9LQH0ED85uThbuACLcBGAsYHQ/s320/Screenshot%2B2021-06-11%2B231550.png"/></a></div>

<p>
The primary requirement is to map the avatar bones to the controlled robot bones and the code synchronizes the respective joint rotations. I'm sure there are more elegant solutions, but I thought I would post <a href="https://github.com/genereddick/BodyTracking">my version</a> on GitHub in case it helps anyone else attempting this. Feel free to make suggestions or point towards better solutions that may be out there.
</p>

<div>
  <span>Another avatar:</span>
  
<div class="separator" style="clear: both;"><a href="https://1.bp.blogspot.com/-LTncndWNfoE/YMRRLCraXjI/AAAAAAAAgOI/ZzCBa22HdIYhnNIyeuE6XVupuh_4YuBzgCLcBGAsYHQ/s1173/robot1.png" style="display: block; padding: 1em 0; text-align: center; "><img alt="" border="0" width="320" data-original-height="994" data-original-width="1173" src="https://1.bp.blogspot.com/-LTncndWNfoE/YMRRLCraXjI/AAAAAAAAgOI/ZzCBa22HdIYhnNIyeuE6XVupuh_4YuBzgCLcBGAsYHQ/s320/robot1.png"/></a></div>

<div class="separator" style="clear: both;"><a href="https://1.bp.blogspot.com/-gRXLPpuWRUA/YMRRLDmaBRI/AAAAAAAAgOM/ZrP9KEA4RO4RVjqczAKxjb7Q6wXzp1lsACLcBGAsYHQ/s1324/robot2.png" style="display: block; padding: 1em 0; text-align: center; "><img alt="" border="0" width="320" data-original-height="981" data-original-width="1324" src="https://1.bp.blogspot.com/-gRXLPpuWRUA/YMRRLDmaBRI/AAAAAAAAgOM/ZrP9KEA4RO4RVjqczAKxjb7Q6wXzp1lsACLcBGAsYHQ/s320/robot2.png"/></a></div>
</div>

<p>There are still issues with initial positions and offsets especially when live on an iOS device, and models lose tracking and experience jitter every now and than, so still a work in process.</p>

<dl>
  <dt>Apple documentation:</dt>
  <dd><a href="https://developer.apple.com/documentation/arkit/content_anchors/rigging_a_model_for_motion_capture">https://developer.apple.com/documentation/arkit/content_anchors/rigging_a_model_for_motion_capture</a></dd>
  
  <dt>AR Foundation Sample Project:</dt>
  <dd><a href="https://github.com/Unity-Technologies/arfoundation-samples">https://github.com/Unity-Technologies/arfoundation-samples</a></dd>
  
</dl>
