import MainLayout from "components/MainLayout";
import PageLayout from "components/PageLayout";

import LayoutDashboardNotificationList from "./LayoutDashboardNotificationList";
import LayoutDashboardResume from "./LayoutDashboardResume";

const LayoutDashboard = () => {
  return (
    <MainLayout>
      <PageLayout pageTitle="Página Inicial">
        <LayoutDashboardResume />

        <LayoutDashboardNotificationList />
      </PageLayout>
    </MainLayout>
  );
};

export default LayoutDashboard;
