//
//  GothPortal_WidgetBundle.swift
//  GothPortal Widget
//
//  Created by Ethan Duke on 12/22/22.
//

import WidgetKit
import SwiftUI

@main
struct GothPortal_WidgetBundle: WidgetBundle {
    var body: some Widget {
        GothPortal_Widget()
        GothPortal_WidgetLiveActivity()
    }
}
