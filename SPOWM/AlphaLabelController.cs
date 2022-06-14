using EFT.UI;
using TMPro;
using UnityEngine;

namespace SPOWM
{
    class AlphaLabelController : MonoBehaviour
    {
		private string _alphaStringCache = "";
		private string _serverCode = "";
		private string _commit = "";
		private string _version = "";
		private string _label = "";
		private bool _cachedVersion = false;

		protected void Update()
		{
			if (PreloaderUI.Instance == null)
				return;

			string suffix = _serverCode ?? "";
			var alphaLabel = GameObject.Find("AlphaLabel").GetComponent<TextMeshProUGUI>();
			if (alphaLabel == null)
				return;

			if (alphaLabel.text.Length < 1)
				return;

			var labels = alphaLabel.text.Split('|');

			if (!_cachedVersion)
			{
				_alphaStringCache = labels[0].Trim();
				SPOVersion.ReturnVersion(out _commit, out _version);
				_cachedVersion = true;
				return;
			}

			if (alphaLabel.text.Contains($"{_alphaStringCache} | ") && !alphaLabel.text.Contains(_version))
			{
				_serverCode = labels.Length > 1 ? $" | {labels[1].Trim()}" : null;
			}

			if (_label != alphaLabel.text)
			{
				_label = $"{_alphaStringCache} | {_version} | {_commit}" + suffix;
				alphaLabel.text = _label;
			}
		}
	}
}
