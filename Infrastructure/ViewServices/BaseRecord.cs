using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;
using Infrastructure.Views;

namespace Infrastructure.Views
{
	public static class BaseRecordViewService
	{
		public static void SetBaseRecordValues(this BaseRecordView view, BaseRecord entity)
		{
			view.createdAt = entity.CreatedAt;
			view.updatedBy = entity.UpdatedBy;
			view.order = entity.Order;
			view.lastUpdated = entity.LastUpdated;
			view.removed = entity.Removed;
			view.active = entity.Active;
		}
	}
}
