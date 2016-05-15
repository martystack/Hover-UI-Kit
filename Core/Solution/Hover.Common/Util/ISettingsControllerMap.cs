﻿using System.Collections.Generic;

namespace Hover.Common.Util {

	/*================================================================================================*/
	public interface ISettingsControllerMap {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Set(string pValueName, ISettingsController pController);

		/*--------------------------------------------------------------------------------------------*/
		ISettingsController Get(string pValueName);

		/*--------------------------------------------------------------------------------------------*/
		bool IsControlled(string pValueName);

		/*--------------------------------------------------------------------------------------------*/
		bool AreAnyControlled();

		/*--------------------------------------------------------------------------------------------*/
		int GetControlledCount();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		List<string> GetNewListOfControlledValueNames();

		/*--------------------------------------------------------------------------------------------*/
		void FillListWithControlledValueNames(List<string> pList);

	}

}
