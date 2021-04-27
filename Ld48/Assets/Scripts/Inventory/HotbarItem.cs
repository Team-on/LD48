using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using NaughtyAttributes;
using Random = UnityEngine.Random;

public class HotbarItem : InventoryItem, IPointerClickHandler {
	[Header("Refs self"), Space]
	[SerializeField] Image selectedFrameLeftImage;
	[SerializeField] Image selectedFrameRightImage;
	[SerializeField] Image selectedFrameBothImage;

	Hotbar hotbar;

	bool isSelectLeft;
	bool isSelectRight;

	protected override void Awake() {
		base.Awake();

		hotbar = inventory as Hotbar;

		selectedFrameLeftImage.color = selectedFrameLeftImage.color.SetA(0.0f);
		selectedFrameRightImage.color = selectedFrameRightImage.color.SetA(0.0f);
		selectedFrameBothImage.color = selectedFrameBothImage.color.SetA(0.0f);
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left) {
			hotbar.SetSelection(id, true);
		}
		else if (eventData.button == PointerEventData.InputButton.Right) {
			hotbar.SetSelection(id, false);
		}
		else if (eventData.button == PointerEventData.InputButton.Middle) {
			hotbar.SetSelection(id, true);
			hotbar.SetSelection(id, false);
		}
	}

	public void SetSelectedFrame(bool isLeftHand) {

		if (isLeftHand)
			isSelectLeft = true;
		else
			isSelectRight = true;

		if (isLeftHand) {
			if (isSelectRight) {
				LeanTween.cancel(selectedFrameRightImage.gameObject, false);
				LeanTween.cancel(selectedFrameBothImage.gameObject, false);
				
				LeanTweenEx.ChangeAlpha(selectedFrameRightImage, 0.0f, 0.1f);
				LeanTweenEx.ChangeAlpha(selectedFrameBothImage, 1.0f, 0.1f);
			}
			else {
				LeanTween.cancel(selectedFrameLeftImage.gameObject, false);
				
				LeanTweenEx.ChangeAlpha(selectedFrameLeftImage, 1.0f, 0.1f);
			}
		}
		else {
			if (isSelectLeft) {
				LeanTween.cancel(selectedFrameLeftImage.gameObject, false);
				LeanTween.cancel(selectedFrameBothImage.gameObject, false);

				LeanTweenEx.ChangeAlpha(selectedFrameLeftImage, 0.0f, 0.1f);
				LeanTweenEx.ChangeAlpha(selectedFrameBothImage, 1.0f, 0.1f);
			}
			else {
				LeanTween.cancel(selectedFrameRightImage.gameObject, false);
				
				LeanTweenEx.ChangeAlpha(selectedFrameRightImage, 1.0f, 0.1f);
			}
		}
	}

	public void RemoveSelectedFrame(bool isLeftHand) {
		LeanTween.cancel(gameObject, false);

		if (isLeftHand)
			isSelectLeft = false;
		else
			isSelectRight = false;

		if (isLeftHand) {
			if (isSelectRight) {
				LeanTween.cancel(selectedFrameRightImage.gameObject, false);
				LeanTween.cancel(selectedFrameBothImage.gameObject, false);

				LeanTweenEx.ChangeAlpha(selectedFrameBothImage, 0.0f, 0.1f);
				LeanTweenEx.ChangeAlpha(selectedFrameRightImage, 1.0f, 0.1f);
			}
			else {
				LeanTween.cancel(selectedFrameLeftImage.gameObject, false);
				
				LeanTweenEx.ChangeAlpha(selectedFrameLeftImage, 0.0f, 0.1f);
			}
		}
		else {
			if (isSelectLeft) {
				LeanTween.cancel(selectedFrameLeftImage.gameObject, false);
				LeanTween.cancel(selectedFrameBothImage.gameObject, false);

				LeanTweenEx.ChangeAlpha(selectedFrameBothImage, 0.0f, 0.1f);
				LeanTweenEx.ChangeAlpha(selectedFrameLeftImage, 1.0f, 0.1f);
			}
			else {
				LeanTween.cancel(selectedFrameRightImage.gameObject, false);
			
				LeanTweenEx.ChangeAlpha(selectedFrameRightImage, 0.0f, 0.1f);
			}
		}
	}
}
