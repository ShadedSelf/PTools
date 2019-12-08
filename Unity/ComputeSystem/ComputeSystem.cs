using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ComputeSystem
{
	public ComputeShader shader	{ get; private set; }

	private Dictionary<string, ComputeKernel> kernels = new Dictionary<string, ComputeKernel>();
	private bool profile;

	public ComputeSystem(ComputeShader shader, bool profile = false)
	{
		this.shader		= shader;
		this.profile	= profile;
	}

	//-- Add: -----------------
	public void AddKernel(string name, Vector3Int threads) => kernels.Add(name, new ComputeKernel(name, shader, threads));

	//-- Set: -----------------
	public void BindComputeData(ComputeData data)
	{
		foreach (var kernel in kernels.Values)
		{
			foreach (var buffer in data.buffers)	{ kernel.SetBuffer(buffer.Key, buffer.Value);		}
			foreach (var texture in data.textures)	{ kernel.SetTexture(texture.Key, texture.Value);	}
		}
	}

	public void SetBuffer(string kernel, string bufferName, ComputeBuffer buffer)		=> kernels[kernel].SetBuffer(bufferName, buffer);
	public void SetRenderTexture(string kernel, string textureName, RenderTexture rt)	=> kernels[kernel].SetTexture(textureName, rt);

	//-- Dispatch: ------------
	public void Dispatch(string kernel)								=> kernels[kernel].Dispacth();
	public void RecordDispatch(string kernel, CommandBuffer cmdBuf) => kernels[kernel].RecordDispatch(cmdBuf, profile);

// 	//-- Clean: ---------------
// 	public void Cleanup()
// 	{
// 		kernels.Clear();
// 	}
}
