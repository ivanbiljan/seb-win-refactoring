﻿/*
 * Copyright (c) 2018 ETH Zürich, Educational Development and Technology (LET)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SafeExamBrowser.Contracts.I18n;
using SafeExamBrowser.Contracts.Logging;
using SafeExamBrowser.Core.Behaviour.Operations;

namespace SafeExamBrowser.Core.UnitTests.Behaviour.Operations
{
	[TestClass]
	public class I18nOperationTests
	{
		private Mock<ILogger> loggerMock;
		private Mock<IText> textMock;

		private I18nOperation sut;

		[TestInitialize]
		public void Initialize()
		{
			loggerMock = new Mock<ILogger>();
			textMock = new Mock<IText>();

			sut = new I18nOperation(loggerMock.Object, textMock.Object);
		}

		[TestMethod]
		public void MustPerformCorrectly()
		{
			sut.Perform();

			textMock.Verify(t => t.Initialize(It.IsAny<ITextResource>()), Times.Once);
		}
	}
}
