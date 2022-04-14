import PageLayout from "components/PageLayout";

import LayoutDashboardNotificationList from "./LayoutDashboardNotificationList";
import LayoutDashboardResume from "./LayoutDashboardResume";

const LayoutDashboard = () => {
  return (
    <PageLayout pageTitle="Página Inicial">
      <LayoutDashboardResume />

      <LayoutDashboardNotificationList />
    </PageLayout>
  );
};

export default LayoutDashboard;
